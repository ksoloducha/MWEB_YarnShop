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
    public class YarnBundlesController : Controller
    {
        public IConfiguration Configuration;

        public YarnBundlesController(IConfiguration configuration)
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
            List<YarnBundleVM> yarnBundleList = new List<YarnBundleVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    yarnBundleList = JsonConvert.DeserializeObject<List<YarnBundleVM>>(apiResponse);
                }
            }

            return View(yarnBundleList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            YarnBundleVM y = new YarnBundleVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    y = JsonConvert.DeserializeObject<YarnBundleVM>(apiResponse);
                }
            }

            return View(y);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(YarnBundleVM y)
        {
            string _restpath = GetHostUrl().Content + ControllerName();
            YarnBundleVM yarnBundleResult = new YarnBundleVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(y);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{y.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        yarnBundleResult = JsonConvert.DeserializeObject<YarnBundleVM>(apiResponse);
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

            YarnBundleVM y = new YarnBundleVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    y = JsonConvert.DeserializeObject<YarnBundleVM>(apiResponse);
                }
            }

            return View(y);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(YarnBundleVM y)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            YarnBundleVM yResult = new YarnBundleVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(y);

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{y.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        yResult = JsonConvert.DeserializeObject<YarnBundleVM>(apiResponse);
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
        public async Task<IActionResult> Create(YarnBundleVM y)
        {
            string _yarnTypeRestpath = GetHostUrl().Content + "YarnTypes";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_yarnTypeRestpath}/{y.YarnType.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        YarnTypeVM yarnType = JsonConvert.DeserializeObject<YarnTypeVM>(apiResponse);
                        y.YarnType.Color = yarnType.Color;
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            string _restpath = GetHostUrl().Content + ControllerName();

            YarnBundleVM yResult = new YarnBundleVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(y);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        yResult = JsonConvert.DeserializeObject<YarnBundleVM>(apiResponse);
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
    }
}
