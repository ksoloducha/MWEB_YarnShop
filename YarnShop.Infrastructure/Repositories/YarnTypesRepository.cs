using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class YarnTypesRepository : IYarnTypesRepository
    {

        private AppDbContext _appDbContext;

        public YarnTypesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(YarnType y)
        {
            try
            {
                _appDbContext.YarnType.Add(y);
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
                _appDbContext.Remove(_appDbContext.YarnType.Include(y => y.Color).FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<YarnType>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.YarnType.Include(y => y.Color));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<YarnType> GetAsync(int id)
        {
            try
            {
                return _appDbContext.YarnType.Include(y => y.Color).FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(YarnType y)
        {
            try
            {
                var s = _appDbContext.YarnType.Include(y => y.Color).FirstOrDefault(x => x.Id == y.Id);
                s.Weight = y.Weight;
                s.Length = y.Length;
                s.NeedlesSize = y.NeedlesSize;
                s.price = y.price;
                s.Color = y.Color;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
