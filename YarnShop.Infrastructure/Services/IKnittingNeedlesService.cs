using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public interface IKnittingNeedlesService
    {
        public Task<IEnumerable<KnittingNeedleDTO>> BrowseAll();
        public Task<IEnumerable<KnittingNeedleDTO>> BrowseAllAndFilterSize(double minSize);
        public Task<KnittingNeedleDTO> GetById(int id);
        public Task <KnittingNeedleDTO> AddCrochetHook(KnittingNeedle knittingNeedle);
        public Task DeleteCrochetHook(int id);
        public Task<KnittingNeedleDTO> EditCrochetHook(KnittingNeedle knittingNeedle, int id);
    }
}
