using Microsoft.AspNetCore.Mvc;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Repositories;
using YarnShop.Infrastructure.Services;

namespace YarnShop.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class ColorsController : Controller
    {
        private readonly IColorsService _colorsService;
        private AppDbContext _dbContext;

        public ColorsController(IColorsService colorsService)
        {
            _colorsService = colorsService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllColors()
        {
            IEnumerable<ColorDTO> k = await _colorsService.BrowseAll();
            Console.WriteLine($"Get all colors: {k}");
            return Json(k);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColor(int id)
        {
            ColorDTO k = await _colorsService.GetById(id);
            Console.WriteLine($"Get kit: {k}");
            return Json(k);
        }

        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] Color color)
        {
            ColorDTO k = await _colorsService.AddColor(color);
            Console.WriteLine($"Post color: {k}");
            return Json(k);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatColor([FromBody] Color color, int id)
        {
            ColorDTO k = await _colorsService.EditColor(color, id);
            Console.WriteLine($"Put colo: {k}");
            return Json(k);
        }

        [HttpDelete]
        public async Task DeleteColor(int id)
        {
            Console.WriteLine($"Delete color: id {id}");
            await _colorsService.DeleteColor(id);
        }
    }
}
