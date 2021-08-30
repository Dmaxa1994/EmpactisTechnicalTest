using EmpactisTechnicalTestApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmpactisTechnicalTestApi.Data
{
    public class RepositoryDBContext : DbContext
    {
        private readonly DbContextOptions _options;
        public RepositoryDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Absence> Absences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
