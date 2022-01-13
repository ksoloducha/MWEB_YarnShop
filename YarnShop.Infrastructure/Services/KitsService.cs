using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public class KitsService : IKitsService
    {
        private readonly IKitsRepository _kitsRepository;

        public KitsService(IKitsRepository kitsRepository)
        {
            _kitsRepository = kitsRepository;
        }

        public async Task<KitDTO> AddKit(Kit kit)
        {
            Kit k = new Kit()
            {
                yarnType = kit.yarnType,
                n = kit.n,
                Tool = kit.Tool,
                Pattern = kit.Pattern
            };
            await _kitsRepository.AddAsync(k);
            return new KitDTO()
            {
                yarnType = YarnTypesService.mapToDTO(kit.yarnType),
                n = kit.n,
                Tool = KnittingNeedlesService.mapToDTO(kit.Tool),
                Pattern = kit.Pattern
            };
        }

        public async Task<IEnumerable<KitDTO>> BrowseAll()
        {
            var k = await _kitsRepository.GetAllAsync();
            return k.Select(x => mapToDTO(x));
        }

        private KitDTO mapToDTO(Kit x)
        {
            return new KitDTO()
            {
                Id = x.Id,
                yarnType = YarnTypesService.mapToDTO(x.yarnType),
                n = x.n,
                Tool = KnittingNeedlesService.mapToDTO(x.Tool),
                Pattern = x.Pattern
            };
        }

        public async Task DeleteKit(int id)
        {
            await _kitsRepository.DeleteAsync(id);
        }

        public async Task<KitDTO> EditKit(Kit kit, int id)
        {
            Kit updatedKit = new Kit()
            {
                Id = id,
                yarnType = kit.yarnType,
                n = kit.n,
                Tool = kit.Tool,
                Pattern = kit.Pattern
            };
            await _kitsRepository.UpdateAsync(updatedKit);
            return mapToDTO(updatedKit);
        }

        public async Task<KitDTO> GetById(int id)
        {
            var kit = await _kitsRepository.GetAsync(id);
            return mapToDTO(kit);
        }
    }
}
