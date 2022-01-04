using Microsoft.AspNetCore.Mvc;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Services;

namespace YarnShop.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class YarnTypesController : Controller
    {
        private readonly IYarnTypesService _yarnTypesService;

        public YarnTypesController(IYarnTypesService yarnTypesService)
        {
            _yarnTypesService = yarnTypesService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllYarnTypes()
        {
            IEnumerable<YarnTypeDTO> y = await _yarnTypesService.BrowseAll();
            Console.WriteLine($"Get all yarn types: {y}");
            return Json(y);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetYarnType(int id)
        {
            YarnTypeDTO y = await _yarnTypesService.GetById(id);
            Console.WriteLine($"Get yarn type: {y}");
            return Json(y);
        }

        [HttpPost]
        public async Task<IActionResult> AddYarnType([FromBody] YarnType yarnType)
        {
            YarnTypeDTO y = await _yarnTypesService.AddYarnType(yarnType);
            Console.WriteLine($"Post yarn type: {y}");
            return Json(y);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateYarnType([FromBody] YarnType yarnType, int id)
        {
            YarnTypeDTO y = await _yarnTypesService.EditYarnType(yarnType, id);
            Console.WriteLine($"Put yarn type: {y}");
            return Json(y);
        }

        [HttpDelete]
        public async Task DeleteYarnType(int id)
        {
            Console.WriteLine($"Delete yarn type: id {id}");
            await _yarnTypesService.DeleteYarnType(id);
        }
    }
}
