using Microsoft.AspNetCore.Http;
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
    public class YarnTypesController : Controller
    {
        public IConfiguration Configuration;

        public YarnTypesController(IConfiguration configuration)
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

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            YarnTypeVM y = new YarnTypeVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    y = JsonConvert.DeserializeObject<YarnTypeVM>(apiResponse);
                }
            }

            return View(y);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(YarnTypeVM y)
        {
            string _restpath = GetHostUrl().Content + ControllerName();
            YarnTypeVM yarnTypeResult = new YarnTypeVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(y);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{y.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        yarnTypeResult = JsonConvert.DeserializeObject<YarnTypeVM>(apiResponse);
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

            YarnTypeVM y = new YarnTypeVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    y = JsonConvert.DeserializeObject<YarnTypeVM>(apiResponse);
                }
            }

            return View(y);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(YarnTypeVM y)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            YarnTypeVM yResult = new YarnTypeVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(y);

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{y.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        yResult = JsonConvert.DeserializeObject<YarnTypeVM>(apiResponse);
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
        public async Task<IActionResult> Create(YarnTypeVM y)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            YarnTypeVM yResult = new YarnTypeVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(y);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        yResult = JsonConvert.DeserializeObject<YarnTypeVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ColorsList()
        {
            string _restpath = GetHostUrl().Content + "Colors";
            List<ColorVM> colorList = new List<ColorVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    colorList = JsonConvert.DeserializeObject<List<ColorVM>>(apiResponse);
                }
            }

            return View(colorList);
        }
    }
}
