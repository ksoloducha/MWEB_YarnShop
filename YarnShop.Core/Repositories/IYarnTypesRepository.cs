using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    internal interface IYarnTypesRepository
    {
        Task UpdateAsync(YarnType y);
        Task DeleteAsync(YarnType y);
        Task AddAsync(YarnType y);
        Task<YarnType> GetAsync(int id);
        Task<IEnumerable<YarnType>> GetAllAsync();
    }
}
