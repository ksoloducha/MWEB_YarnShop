using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class YarnBundlesRepository : IYarnBundlesRepository
    {

        private AppDbContext _appDbContext;

        public YarnBundlesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(YarnBundle y)
        {
            try
            {
                YarnType yarnType = _appDbContext.YarnType.FirstOrDefault(x => x.Id == y.YarnType.Id);
                if (yarnType != null)
                {
                    y.YarnType = yarnType;
                    y.YarnType.Color = yarnType.Color;
                }
                _appDbContext.YarnBundles.Add(y);
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
                _appDbContext.Remove(_appDbContext.YarnBundles.Include(y => y.YarnType).ThenInclude(y => y.Color).FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<YarnBundle>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.YarnBundles.Include(y => y.YarnType).ThenInclude(y => y.Color));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<YarnBundle> GetAsync(int id)
        {
            try
            {
                return _appDbContext.YarnBundles.Include(y => y.YarnType).ThenInclude(y => y.Color).FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(YarnBundle y)
        {
            try
            {
                YarnType yarnType = _appDbContext.YarnType.FirstOrDefault(x => x.Id == y.YarnType.Id);
                if (yarnType != null)
                {
                    y.YarnType = yarnType;
                    y.YarnType.Color = yarnType.Color;
                }
                var s = _appDbContext.YarnBundles.Include(y => y.YarnType).ThenInclude(y => y.Color).FirstOrDefault(x => x.Id == y.Id);
                s.YarnType = y.YarnType;
                s.n = y.n;
                s.PricePercentage = y.PricePercentage;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
