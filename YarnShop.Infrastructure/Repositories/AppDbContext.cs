using Microsoft.EntityFrameworkCore;
using YarnShop.Core.Domain;

namespace YarnShop.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Color> Color { 
            get; 
            set; 
        }
        public DbSet<YarnType> YarnType { get; set; }
        public DbSet<YarnBundle> YarnBundles { get; set; }
        public DbSet<KnittingNeedle> KnittingNeedle { get; set; }
        public DbSet<Kit> Kit { get; set; }
    }
}
