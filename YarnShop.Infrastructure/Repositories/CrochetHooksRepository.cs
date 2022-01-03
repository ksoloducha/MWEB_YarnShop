using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class CrochetHooksRepository : ICrochetHooksRepository
    {
        public Task AddAsync(CrochetHook c)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(CrochetHook c)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CrochetHook>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CrochetHook> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CrochetHook>> GetSizeEqualOrBigger(double size)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(CrochetHook c)
        {
            throw new System.NotImplementedException();
        }
    }
}
