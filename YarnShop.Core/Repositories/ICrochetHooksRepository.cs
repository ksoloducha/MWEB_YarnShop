using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    public interface ICrochetHooksRepository
    {
        Task UpdateAsync(CrochetHook c);
        Task DeleteAsync(CrochetHook c);
        Task AddAsync(CrochetHook c);
        Task<CrochetHook> GetAsync(int id);
        Task<IEnumerable<CrochetHook>> GetAllAsync();
        Task<IEnumerable<CrochetHook>> GetSizeEqualOrBigger(double size);
    }
}
