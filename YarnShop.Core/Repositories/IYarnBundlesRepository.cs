using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    internal interface IYarnBundlesRepository
    {
        Task UpdateAsync(YarnBundle y);
        Task DeleteAsync(YarnBundle y);
        Task AddAsync(YarnBundle y);
        Task<YarnBundle> GetAsync(int id);
        Task<IEnumerable<YarnBundle>> GetAllAsync();
    }
}
