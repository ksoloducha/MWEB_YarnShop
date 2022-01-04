using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public interface IKitsService
    {
        public Task<IEnumerable<KitDTO>> BrowseAll();
        public Task<KitDTO> GetById(int id);
        public Task<KitDTO> AddKit(Kit kit);
        public Task DeleteKit(int id);
        public Task<KitDTO> EditKit(Kit kit, int id);
    }
}
