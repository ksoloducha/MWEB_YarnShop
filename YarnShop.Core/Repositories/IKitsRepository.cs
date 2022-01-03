using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    internal interface IKitsRepository
    {
        Task UpdateAsync(Kit k);
        Task DeleteAsync(Kit k);
        Task AddAsync(Kit k);
        Task<Kit> GetAsync(int id);
        Task<IEnumerable<Kit>> GetAllAsync();
    }
}
