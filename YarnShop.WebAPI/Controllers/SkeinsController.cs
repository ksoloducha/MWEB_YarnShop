using Microsoft.AspNetCore.Mvc;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Services;

namespace YarnShop.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class SkeinsController : Controller
    {
        private readonly ISkeinsService _skeinsService;

        public SkeinsController(ISkeinsService skeinsService)
        {
            _skeinsService = skeinsService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseSkeins()
        {
            IEnumerable<SkeinDTO> s = await _skeinsService.BrowseAll();
            Console.WriteLine($"Get all skeins: {s}");
            return Json(s);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeSkein(int id)
        {
            SkeinDTO s = await _skeinsService.GetById(id);
            Console.WriteLine($"Get skein: {s}");
            return Json(s);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkein([FromBody] Skein skein)
        {
            SkeinDTO s = await _skeinsService.AddSkein(skein);
            Console.WriteLine($"Post skein: {s}");
            return Json(s);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatSkein([FromBody] Skein skein, int id)
        {
            SkeinDTO s = await _skeinsService.EditSkein(skein, id);
            Console.WriteLine($"Put skein: {s}");
            return Json(s);
        }

        [HttpDelete]
        public async Task DeleteSkein(int id)
        {
            Console.WriteLine($"Delete skein: id {id}");
            await _skeinsService.DeleteSkein(id);
        }
    }
}
