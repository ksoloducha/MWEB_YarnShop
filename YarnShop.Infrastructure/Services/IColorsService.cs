using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public interface IColorsService
    {
        public Task<IEnumerable<ColorDTO>> BrowseAll();
        public Task<ColorDTO> GetById(int id);
        public Task<ColorDTO> AddColor(Color color);
        public Task DeleteColor(int id);
        public Task<ColorDTO> EditColor(Color color, int id);
    }
}
