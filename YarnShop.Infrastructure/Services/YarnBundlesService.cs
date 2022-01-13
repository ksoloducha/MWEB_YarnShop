using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public class YarnBundlesService : IYarnBundlesService
    {
        private readonly IYarnBundlesRepository _yarnBundlesRepository;

        public YarnBundlesService(IYarnBundlesRepository yarnBundlesRepository)
        {
            _yarnBundlesRepository = yarnBundlesRepository;
        }
        public async Task<YarnBundleDTO> AddYarnBundle(YarnBundle yarnBundle)
        {
            YarnBundle y = new YarnBundle()
            {
                YarnType = yarnBundle.YarnType,
                n = yarnBundle.n,
                PricePercentage = yarnBundle.PricePercentage
            };
            await _yarnBundlesRepository.AddAsync(y);
            return new YarnBundleDTO()
            {
                YarnType = YarnTypesService.mapToDTO(yarnBundle.YarnType),
                n = yarnBundle.n,
                PricePercentage = yarnBundle.PricePercentage
            };
        }

        public async Task<IEnumerable<YarnBundleDTO>> BrowseAll()
        {
            var y = await _yarnBundlesRepository.GetAllAsync();
            return y.Select(x => mapToDTO(x));
        }

        private YarnBundleDTO mapToDTO(YarnBundle x)
        {
            return new YarnBundleDTO()
            {
                Id = x.Id,
                YarnType = YarnTypesService.mapToDTO(x.YarnType),
                n = x.n,
                PricePercentage = x.PricePercentage
            };
        }

        public async Task DeleteYarnBundle(int id)
        {
            await _yarnBundlesRepository.DeleteAsync(id);
        }

        public async Task<YarnBundleDTO> EditYarnBundle(YarnBundle yarnBundle, int id)
        {
            YarnBundle updatedYarnBundle = new YarnBundle()
            {
                Id = id,
                YarnType=yarnBundle.YarnType,
                n = yarnBundle.n,
                PricePercentage=yarnBundle.PricePercentage
            };
            await _yarnBundlesRepository.UpdateAsync(updatedYarnBundle);
            return mapToDTO(updatedYarnBundle);
        }

        public async Task<YarnBundleDTO> GetById(int id)
        {
            var y = await _yarnBundlesRepository.GetAsync(id);
            return mapToDTO(y);
        }
    }
}
