using Microsoft.EntityFrameworkCore;
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
                YarnType yarnType = _appDbContext.YarnType.FirstOrDefault(x => x.Id == k.yarnType.Id);
                if (yarnType != null)
                {
                    k.yarnType = yarnType;
                }
                KnittingNeedle knittingNeedle = _appDbContext.KnittingNeedle.FirstOrDefault(x => x.Id == k.Tool.Id);
                if (yarnType != null)
                {
                    k.Tool = knittingNeedle;
                }
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
                _appDbContext.Remove(_appDbContext.Kit
                                        .Include(k => k.yarnType).ThenInclude(y => y.Color)
                                        .Include(k => k.Tool)
                                        .FirstOrDefault(x => x.Id == id));
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
                var kits = _appDbContext.Kit
                                        .Include(k => k.yarnType).ThenInclude(y => y.Color)
                                        .Include(k => k.Tool);
                return await Task.FromResult(kits);
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
                return _appDbContext.Kit
                                    .Include(k => k.yarnType).ThenInclude(y => y.Color)
                                    .Include(k => k.Tool)
                                    .FirstOrDefault(x => x.Id == id);
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
                YarnType yarnType = _appDbContext.YarnType.FirstOrDefault(x => x.Id == k.yarnType.Id);
                if (yarnType != null)
                {
                    k.yarnType = yarnType;
                }
                KnittingNeedle knittingNeedle = _appDbContext.KnittingNeedle.FirstOrDefault(x => x.Id == k.Tool.Id);
                if (yarnType != null)
                {
                    k.Tool = knittingNeedle;
                }
                var s = _appDbContext.Kit
                                        .Include(k => k.yarnType).ThenInclude(y => y.Color)
                                        .Include(k => k.Tool)
                                        .FirstOrDefault(x => x.Id == k.Id);
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
