using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public interface IYarnTypesService
    {
        public Task<IEnumerable<YarnTypeDTO>> BrowseAll();
        public Task<YarnTypeDTO> GetById(int id);
        public Task<YarnTypeDTO> AddYarnType(YarnType yarnType);
        public Task DeleteYarnType(int id);
        public Task<YarnTypeDTO> EditYarnType(YarnType yarnType, int id);
    }
}
