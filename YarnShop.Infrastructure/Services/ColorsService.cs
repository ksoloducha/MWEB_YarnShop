using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public class ColorsService : IColorsService
    {
        private readonly IColorsRepository _colorsRepository;

        public ColorsService(IColorsRepository colorsRepository)
        {
            _colorsRepository = colorsRepository;
        }
        public async Task<ColorDTO> AddColor(Color color)
        {
            Color c = new Color()
            {
                Name = color.Name,
                n = color.n
            };
            await _colorsRepository.AddAsync(c);
            return new ColorDTO()
            {
                Name = color.Name,
                n = color.n
            };
        }

        public async Task<IEnumerable<ColorDTO>> BrowseAll()
        {
            var c = await _colorsRepository.GetAllAsync();
            return c.Select(x => mapToDTO(x));
        }

        public static ColorDTO mapToDTO(Color x)
        {
            return new ColorDTO()
            {
                Id = x.Id,
                Name = x.Name,
                n = x.n
            };
        }

        public async Task DeleteColor(int id)
        {
            await _colorsRepository.DeleteAsync(id);
        }

        public async Task<ColorDTO> EditColor(Color color, int id)
        {
            Color updatedColor = new Color()
            {
                Id = id,
                Name = color.Name,
                n = color.n
            };
            await _colorsRepository.UpdateAsync(updatedColor);
            return mapToDTO(updatedColor);
        }

        public async Task<ColorDTO> GetById(int id)
        {
            var color = await _colorsRepository.GetAsync(id);
            return mapToDTO(color);
        }
    }
}
