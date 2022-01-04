using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    public interface ISkeinsRepository
    {
        Task UpdateAsync(Skein s);
        Task DeleteAsync(int id);
        Task AddAsync(Skein s);
        Task<Skein> GetAsync(int id);
        Task<IEnumerable<Skein>> GetAllAsync();
    }
}
