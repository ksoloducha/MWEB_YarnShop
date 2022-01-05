using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public class YarnTypesService : IYarnTypesService
    {
        private readonly IYarnTypesRepository _yarnTypesRepository;

        public YarnTypesService(IYarnTypesRepository yarnTypesRepository)
        {
            _yarnTypesRepository = yarnTypesRepository;
        }
        public async Task<YarnTypeDTO> AddYarnType(YarnType yarnType)
        {
            YarnType y = new YarnType()
            {
                Weight = yarnType.Weight,
                Length = yarnType.Length,
                NeedlesSize = yarnType.NeedlesSize,
                price = yarnType.price,
                Color = yarnType.Color
            };
            await _yarnTypesRepository.AddAsync(y);
            return new YarnTypeDTO()
            {
                Weight = yarnType.Weight,
                Length = yarnType.Length,
                NeedlesSize = yarnType.NeedlesSize,
                price = yarnType.price,
                Color = yarnType.Color
            };
        }

        public async Task<IEnumerable<YarnTypeDTO>> BrowseAll()
        {
            var y = await _yarnTypesRepository.GetAllAsync();
            return y.Select(x => mapToDTO(x));
        }

        private YarnTypeDTO mapToDTO(YarnType x)
        {
            return new YarnTypeDTO()
            {
                Weight = x.Weight,
                Length = x.Length,
                NeedlesSize = x.NeedlesSize,
                price = x.price,
                Color = x.Color
            };
        }

        public async Task DeleteYarnType(int id)
        {
            await _yarnTypesRepository.DeleteAsync(id);
        }

        public async Task<YarnTypeDTO> EditYarnType(YarnType yarnType, int id)
        {
            YarnType updatedYarnType = new YarnType()
            {
                Id = id,
                Weight = yarnType.Weight,
                Length=yarnType.Length,
                NeedlesSize=yarnType.NeedlesSize,
                price=yarnType.price,
                Color = yarnType.Color
            };
            await _yarnTypesRepository.UpdateAsync(updatedYarnType);
            return mapToDTO(updatedYarnType);
        }

        public async Task<YarnTypeDTO> GetById(int id)
        {
            var y = await _yarnTypesRepository.GetAsync(id);
            return mapToDTO(y);
        }
    }
}
