using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YarnShop.WebApp.Models;

namespace YarnShop.WebApp.Controllers
{
    public class KnittingNeedlesController : Controller
    {
        public IConfiguration Configuration;

        public KnittingNeedlesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private string ControllerName()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }

        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + ControllerName();
            List<KnittingNeedleVM> knittingNeedleList = new List<KnittingNeedleVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    knittingNeedleList = JsonConvert.DeserializeObject<List<KnittingNeedleVM>>(apiResponse);
                }
            }

            return View(knittingNeedleList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            KnittingNeedleVM k = new KnittingNeedleVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    k = JsonConvert.DeserializeObject<KnittingNeedleVM>(apiResponse);
                }
            }

            return View(k);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(KnittingNeedleVM k)
        {
            string _restpath = GetHostUrl().Content + ControllerName();
            KnittingNeedleVM knittingNeedleResult = new KnittingNeedleVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(k);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{k.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        knittingNeedleResult = JsonConvert.DeserializeObject<KnittingNeedleVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            KnittingNeedleVM k = new KnittingNeedleVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    k = JsonConvert.DeserializeObject<KnittingNeedleVM>(apiResponse);
                }
            }

            return View(k);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(KnittingNeedleVM k)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            KnittingNeedleVM kResult = new KnittingNeedleVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(k);

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{k.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        kResult = JsonConvert.DeserializeObject<KnittingNeedleVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(KnittingNeedleVM k)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            KnittingNeedleVM kResult = new KnittingNeedleVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(k);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        kResult = JsonConvert.DeserializeObject<KnittingNeedleVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
