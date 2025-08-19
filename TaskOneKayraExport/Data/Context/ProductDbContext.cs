using Microsoft.EntityFrameworkCore;
using TaskOneKayraExport.Data.Configuration;
using TaskOneKayraExport.Entity;

namespace TaskOneKayraExport.Data.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        DbSet<Product> Product { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

    }
}
