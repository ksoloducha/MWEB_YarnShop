using System.Collections.Generic;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class ColorsRepository : IColorsRepository
    {
        private AppDbContext _appDbContext;

        public ColorsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task AddAsync(Color c)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Color>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Color> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Color c)
        {
            throw new System.NotImplementedException();
        }
    }
}
