using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;

namespace YarnShop.Infrastructure.Repositories
{
    public class KnittingNeedlesRepository : IKnittingNeedlesRepository
    {

        private AppDbContext _appDbContext;

        public KnittingNeedlesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(KnittingNeedle c)
        {
            try
            {
                _appDbContext.KnittingNeedle.Add(c);
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
                _appDbContext.Remove(_appDbContext.KnittingNeedle.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<KnittingNeedle>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.KnittingNeedle);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<KnittingNeedle> GetAsync(int id)
        {
            try
            {
                return _appDbContext.KnittingNeedle.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<KnittingNeedle>> GetSizeEqualOrBigger(double size)
        {
            try
            {
                return await Task.FromResult(_appDbContext.KnittingNeedle.Where(x => x.Size >= size));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(KnittingNeedle c)
        {
            try
            {
                var s = _appDbContext.KnittingNeedle.FirstOrDefault(x => x.Id == c.Id);
                s.Size = c.Size;
                s.n= c.n;
                s.Circular = c.Circular;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
