using Microsoft.EntityFrameworkCore;
using Products.Domain.Entites;
using Products.Infra.Data.MySql.Mapping;

namespace Products.Infra.Data.MySql.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
