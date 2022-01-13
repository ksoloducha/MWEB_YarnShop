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
                /*using (var dupa = _appDbContext.Database.GetDbConnection().CreateCommand())
                {
                    dupa.CommandText = "SELECT * FROM Color";
                    _appDbContext.Database.OpenConnection();
                    using (var r = dupa.ExecuteReader())
                    {
                        
                    }
                }*/
                
                var color = _appDbContext.Color;
                var res = await Task.FromResult(color);
                return res;
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
                c.Name = s.Name;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
