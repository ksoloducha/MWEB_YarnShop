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
    public class KitsController : Controller
    {
        public IConfiguration Configuration;

        public KitsController(IConfiguration configuration)
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
            List<KitVM> kitList = new List<KitVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    kitList = JsonConvert.DeserializeObject<List<KitVM>>(apiResponse);
                }
            }

            return View(kitList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            KitVM k = new KitVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    k = JsonConvert.DeserializeObject<KitVM>(apiResponse);
                }
            }

            return View(k);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(KitVM k)
        {
            string _restpath = GetHostUrl().Content + ControllerName();
            KitVM kitResult = new KitVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(k);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{k.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        kitResult = JsonConvert.DeserializeObject<KitVM>(apiResponse);
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

            KitVM k = new KitVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    k = JsonConvert.DeserializeObject<KitVM>(apiResponse);
                }
            }

            return View(k);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(KitVM k)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            KitVM kResult = new KitVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(k);

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{k.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        kResult = JsonConvert.DeserializeObject<KitVM>(apiResponse);
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
        public async Task<IActionResult> Create(KitVM k)
        {
            string _yarnTypeRestpath = GetHostUrl().Content + "YarnTypes";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_yarnTypeRestpath}/{k.yarnType.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        YarnTypeVM yarnType = JsonConvert.DeserializeObject<YarnTypeVM>(apiResponse);
                        k.yarnType.Color = yarnType.Color;
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            string _restpath = GetHostUrl().Content + ControllerName();

            KitVM kResult = new KitVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(k);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        kResult = JsonConvert.DeserializeObject<KitVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> YarnTypesList()
        {
            string _restpath = GetHostUrl().Content + "YarnTypes";
            List<YarnTypeVM> yarnTypeList = new List<YarnTypeVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    yarnTypeList = JsonConvert.DeserializeObject<List<YarnTypeVM>>(apiResponse);
                }
            }

            return View(yarnTypeList);
        }

        public async Task<IActionResult> KnittingNeedlesList()
        {
            string _restpath = GetHostUrl().Content + "KnittingNeedles";
            List<KnittingNeedleVM> knittingNeedlesList = new List<KnittingNeedleVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    knittingNeedlesList = JsonConvert.DeserializeObject<List<KnittingNeedleVM>>(apiResponse);
                }
            }

            return View(knittingNeedlesList);
        }
    }
}
