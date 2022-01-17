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
    public class KnittingNeedlesController : Controller
    {
        public IConfiguration Configuration;
        private readonly ILogger _logger;

        public KnittingNeedlesController(IConfiguration configuration, ILogger<KnittingNeedlesController> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(ex);
            }
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
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(e);
            }
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
                _logger.LogError(e.Message);
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Filter()
        {
            return View();
        }

        public async Task<IActionResult> FilteredList(MinSizeVM minSizeVM)
        {
            try
            {
                string _restpath = GetHostUrl().Content + ControllerName() + "/filter?size=" + minSizeVM.MinSize;
                List<KnittingNeedleVM> filteredKnittingNeedleList = new List<KnittingNeedleVM>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        filteredKnittingNeedleList = JsonConvert.DeserializeObject<List<KnittingNeedleVM>>(apiResponse);
                    }
                }

                return View(filteredKnittingNeedleList);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(e);
            }
        }
    }
}
