using EmpactisTechnicalTestApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpactisTechnicalTestApi.Model
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        protected TDbContext dbContext;
        private readonly ILogger<Repository<TDbContext>> _logger;

        public Repository(TDbContext context, ILogger<Repository<TDbContext>> logger)
        {
            _logger = logger;
            dbContext = context;
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            _logger.LogInformation("IRepository DB Call for type " + this.GetType().ToString());
            try
            {
                return await this.dbContext.Set<T>().ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed DB call : {ex}", ex.Message);
                return null;
            }
        }

    }
}
