using Microsoft.AspNetCore.Mvc;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Services;

namespace YarnShop.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class YarnBundlesController : Controller
    {
        private readonly IYarnBundlesService _yarnBundlesService;

        public YarnBundlesController(IYarnBundlesService yarnBundlesService)
        {
            _yarnBundlesService = yarnBundlesService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllYarnBundles()
        {
            IEnumerable<YarnBundleDTO> y = await _yarnBundlesService.BrowseAll();
            Console.WriteLine($"Get all yarn bundles: {y}");
            return Json(y);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetYarnBundle(int id)
        {
            YarnBundleDTO y = await _yarnBundlesService.GetById(id);
            Console.WriteLine($"Get yarn bundle: {y}");
            return Json(y);
        }

        [HttpPost]
        public async Task<IActionResult> AddYarnBundle([FromBody] YarnBundle yarnBundle)
        {
            YarnBundleDTO y = await _yarnBundlesService.AddYarnBundle(yarnBundle);
            Console.WriteLine($"Post yarn bundle: {y}");
            return Json(y);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateYarnBundle([FromBody] YarnBundle yarnBundle, int id)
        {
            YarnBundleDTO y = await _yarnBundlesService.EditYarnBundle(yarnBundle, id);
            Console.WriteLine($"Put yarn bundle: {y}");
            return Json(yarnBundle);
        }

        [HttpDelete]
        public async Task DeleteYarnBundle(int id)
        {
            Console.WriteLine($"Delete yarn bundle: id {id}");
            await _yarnBundlesService.DeleteYarnBundle(id);
        }
    }
}
