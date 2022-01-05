﻿using System.Collections.Generic;
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

        public Task AddAsync(YarnType y)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<YarnType>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<YarnType> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(YarnType y)
        {
            throw new System.NotImplementedException();
        }
    }
}
