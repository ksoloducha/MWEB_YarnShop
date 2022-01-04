using Microsoft.AspNetCore.Mvc;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Services;

namespace YarnShop.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class KitsController : Controller
    {
        private readonly IKitsService _kitsService;

        public KitsController(IKitsService kitsService)
        {
            _kitsService = kitsService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllKits()
        {
            IEnumerable<KitDTO> k = await _kitsService.BrowseAll();
            Console.WriteLine($"Get all kits: {k}");
            return Json(k);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKit(int id)
        {
            KitDTO k = await _kitsService.GetById(id);
            Console.WriteLine($"Get kit: {k}");
            return Json(k);
        }

        [HttpPost]
        public async Task<IActionResult> AddKit([FromBody] Kit kit)
        {
            KitDTO k = await _kitsService.AddKit(kit);
            Console.WriteLine($"Post kit: {k}");
            return Json(k);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatKit([FromBody] Kit kit, int id)
        {
            KitDTO k = await _kitsService.EditKit(kit, id);
            Console.WriteLine($"Put kit: {k}");
            return Json(k);
        }

        [HttpDelete]
        public async Task DeleteKit(int id)
        {
            Console.WriteLine($"Delete kit: id {id}");
            await _kitsService.DeleteKit(id);
        }
    }
}
