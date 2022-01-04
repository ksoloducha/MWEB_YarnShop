using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class SkeinsRepository : ISkeinsRepository
    {
        public Task AddAsync(Skein s)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Skein>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Skein> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Skein s)
        {
            throw new System.NotImplementedException();
        }
    }
}
