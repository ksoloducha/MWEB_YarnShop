using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public interface ISkeinsService
    {
        public Task<IEnumerable<SkeinDTO>> BrowseAll();
        public Task<SkeinDTO> GetById(int id);
        public Task<SkeinDTO> AddSkein(Skein skein);
        public Task DeleteSkein(int id);
        public Task<SkeinDTO> EditSkein(Skein skein, int id);
    }
}
