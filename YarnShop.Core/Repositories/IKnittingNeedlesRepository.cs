using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;

namespace YarnShop.Core.Repositories
{
    internal interface IKnittingNeedlesRepository
    {
        Task UpdateAsync(KnittingNeedle k);
        Task DeleteAsync(KnittingNeedle k);
        Task AddAsync(KnittingNeedle k);
        Task<KnittingNeedle> GetAsync(int id);
        Task<IEnumerable<KnittingNeedle>> GetAllAsync();
        Task<IEnumerable<KnittingNeedle>> GetSizeEqualOrBigger(double size);
    }
}
