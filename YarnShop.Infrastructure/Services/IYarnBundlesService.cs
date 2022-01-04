using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Infrastructure.DTO;

namespace YarnShop.Infrastructure.Services
{
    public interface IYarnBundlesService
    {
        public Task<IEnumerable<YarnBundleDTO>> BrowseAll();
        public Task<YarnBundleDTO> GetById(int id);
        public Task<YarnBundleDTO> AddYarnBundle(YarnBundle yarnBundle);
        public Task DeleteYarnBundle(int id);
        public Task<YarnBundleDTO> EditYarnBundle(YarnBundle yarnBundle, int id);
    }
}
