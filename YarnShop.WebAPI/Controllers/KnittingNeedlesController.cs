using Microsoft.AspNetCore.Mvc;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Services;

namespace YarnShop.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class KnittingNeedlesController : Controller
    {
        private readonly IKnittingNeedlesService _crochetHooksService;

        public KnittingNeedlesController(IKnittingNeedlesService crochetHooksService)
        {
            _crochetHooksService = crochetHooksService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAllCrochetHooks()
        {
            IEnumerable<KnittingNeedleDTO> c = await _crochetHooksService.BrowseAll();
            Console.WriteLine($"Get all crochet hooks: {c}");
            return Json(c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCrochetHook(int id)
        {
            KnittingNeedleDTO c = await _crochetHooksService.GetById(id);
            Console.WriteLine($"Get crochet hook: {c}");
            return Json(c);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByMinSize(double size)
        {
            IEnumerable<KnittingNeedleDTO> c = await _crochetHooksService.BrowseAllAndFilterSize(size);
            Console.WriteLine($"Get crochet hooks filtered by size {size}: {c}");
            return Json(c);
        }

        [HttpPost]
        public async Task<IActionResult> AddCrochetHook([FromBody] KnittingNeedle crochetHook)
        {
            KnittingNeedleDTO c = await _crochetHooksService.AddCrochetHook(crochetHook);
            Console.WriteLine($"Post crochet hook: {c}");
            return Json(c);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCrochetHook([FromBody] KnittingNeedle crochetHook, int id)
        {
            KnittingNeedleDTO c =await _crochetHooksService.EditCrochetHook(crochetHook, id);
            Console.WriteLine($"Put crochet hook: {c}");
            return Json(crochetHook);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCrochetHook(int id)
        {
            Console.WriteLine($"Delete crochet hook: id {id}");
            await _crochetHooksService.DeleteCrochetHook(id);
        }
    }
}
