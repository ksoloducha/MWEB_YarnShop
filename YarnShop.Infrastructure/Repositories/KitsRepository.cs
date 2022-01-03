using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    internal class KitsRepository : IKitsRepository
    {
        public Task AddAsync(Kit k)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(Kit k)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Kit>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Kit> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Kit k)
        {
            throw new System.NotImplementedException();
        }
    }
}
