using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public YarnTypesController(IConfiguration configuration, ILogger<YarnTypesController> logger)
        {
            Configuration = configuration;
            _logger = logger;
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
            try
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
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(ex);
            }
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
                _logger.LogError(e.Message);
                return View(e);
            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(e);
            }            
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
                _logger.LogError(e.Message);
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
                _logger.LogError(e.Message);
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ColorsList()
        {
            try
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(e);
            }
        }
    }
}
