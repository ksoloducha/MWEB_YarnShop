using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(Color c)
        {
            try
            {
                _appDbContext.Color.Add(c);
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
                _appDbContext.Remove(_appDbContext.Color.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Color>> GetAllAsync()
        {
            try
            {                
                return await Task.FromResult(_appDbContext.Color);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<Color> GetAsync(int id)
        {
            try
            {
                return _appDbContext.Color.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(Color c)
        {
            try
            {
                var s = _appDbContext.Color.FirstOrDefault(x => x.Id == c.Id);
                s.Name = c.Name;
                s.n = c.n;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
