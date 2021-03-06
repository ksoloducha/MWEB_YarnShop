using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    public interface IYarnTypesRepository
    {
        Task UpdateAsync(YarnType y);
        Task DeleteAsync(int id);
        Task AddAsync(YarnType y);
        Task<YarnType> GetAsync(int id);
        Task<IEnumerable<YarnType>> GetAllAsync();
    }
}
