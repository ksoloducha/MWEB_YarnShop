using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    public interface IYarnBundlesRepository
    {
        Task UpdateAsync(YarnBundle y);
        Task DeleteAsync(int id);
        Task AddAsync(YarnBundle y);
        Task<YarnBundle> GetAsync(int id);
        Task<IEnumerable<YarnBundle>> GetAllAsync();
    }
}
