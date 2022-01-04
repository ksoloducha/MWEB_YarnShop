using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    public interface IKnittingNeedlesRepository
    {
        Task UpdateAsync(KnittingNeedle c);
        Task DeleteAsync(int id);
        Task AddAsync(KnittingNeedle c);
        Task<KnittingNeedle> GetAsync(int id);
        Task<IEnumerable<KnittingNeedle>> GetAllAsync();
        Task<IEnumerable<KnittingNeedle>> GetSizeEqualOrBigger(double size);
    }
}
