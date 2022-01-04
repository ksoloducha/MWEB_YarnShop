using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class YarnBundlesRepository : IYarnBundlesRepository
    {
        public Task AddAsync(YarnBundle y)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<YarnBundle>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<YarnBundle> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(YarnBundle y)
        {
            throw new System.NotImplementedException();
        }
    }
}
