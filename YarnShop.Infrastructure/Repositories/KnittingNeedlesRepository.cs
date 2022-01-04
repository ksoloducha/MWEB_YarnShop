using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class KnittingNeedlesRepository : IKnittingNeedlesRepository
    {
        public Task AddAsync(KnittingNeedle c)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<KnittingNeedle>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<KnittingNeedle> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<KnittingNeedle>> GetSizeEqualOrBigger(double size)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(KnittingNeedle c)
        {
            throw new System.NotImplementedException();
        }
    }
}
