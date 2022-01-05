using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class KitsRepository : IKitsRepository
    {

        private AppDbContext _appDbContext;

        public KitsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Kit k)
        {
            try
            {
                _appDbContext.Kit.Add(k);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Kit.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Kit>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.Kit);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Kit> GetAsync(int id)
        {
            try
            {
                return _appDbContext.Kit.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(Kit k)
        {
            try
            {
                var s = _appDbContext.Kit.FirstOrDefault(x => x.Id == k.Id);
                s.yarnType = k.yarnType;
                s.n = k.n;
                s.Tool = k.Tool;
                s.Pattern = k.Pattern;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
