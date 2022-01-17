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
    public class ColorsController : Controller
    {
        public IConfiguration Configuration;
        private readonly ILogger _logger;

        public ColorsController(IConfiguration configuration, ILogger<ColorsController> logger)
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
            catch (Exception ex)
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

                ColorVM c = new ColorVM();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        c = JsonConvert.DeserializeObject<ColorVM>(apiResponse);
                    }
                }

                return View(c);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(ex);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ColorVM c)
        {
            string _restpath = GetHostUrl().Content + ControllerName();
            ColorVM colorResult = new ColorVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{c.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        colorResult = JsonConvert.DeserializeObject<ColorVM>(apiResponse);
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

                ColorVM c = new ColorVM();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        c = JsonConvert.DeserializeObject<ColorVM>(apiResponse);
                    }
                }

                return View(c);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(e);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ColorVM c)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            ColorVM cResult = new ColorVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{c.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cResult = JsonConvert.DeserializeObject<ColorVM>(apiResponse);
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
        public async Task<IActionResult> Create(ColorVM c)
        {
            string _restpath = GetHostUrl().Content + ControllerName();

            ColorVM cResult = new ColorVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(c);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cResult = JsonConvert.DeserializeObject<ColorVM>(apiResponse);
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
    }
}
