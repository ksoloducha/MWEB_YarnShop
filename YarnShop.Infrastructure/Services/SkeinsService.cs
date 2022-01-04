using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public class SkeinsService : ISkeinsService
    {
        private readonly ISkeinsRepository _skeinsRepository;

        public SkeinsService(ISkeinsRepository skeinsRepository)
        {
            _skeinsRepository = skeinsRepository;
        }

        public async Task<SkeinDTO> AddSkein(Skein skein)
        {
            Skein s  = new Skein()
            {
                YarnType = skein.YarnType,
                AvailableColors = skein.AvailableColors
            };
            await _skeinsRepository.AddAsync(s);
            return new SkeinDTO()
            {
                YarnType = skein.YarnType,
                AvailableColors = skein.AvailableColors
            };
        }

        public async Task<IEnumerable<SkeinDTO>> BrowseAll()
        {
            var s = await _skeinsRepository.GetAllAsync();
            return s.Select(x => mapToDTO(x));
        }

        private SkeinDTO mapToDTO(Skein x)
        {
            return new SkeinDTO()
            {
                Id = x.Id,
                YarnType = x.YarnType,
                AvailableColors = x.AvailableColors
            };
        }

        public async Task DeleteSkein(int id)
        {
            await _skeinsRepository.DeleteAsync(id);
        }

        public async Task<SkeinDTO> EditSkein(Skein skein, int id)
        {
            Skein updatedSkein = new Skein()
            {
                Id = id,
                YarnType = skein.YarnType,
                AvailableColors = skein.AvailableColors
            };
            await _skeinsRepository.UpdateAsync(updatedSkein);
            return mapToDTO(updatedSkein);
        }

        public async Task<SkeinDTO> GetById(int id)
        {
            var skein = await _skeinsRepository.GetAsync(id);
            return mapToDTO(skein);
        }
    }
}
