using Microsoft.EntityFrameworkCore;
using Categories.Domain.Entites;
using Categories.Infra.Data.MySql.Mapping;

namespace Categories.Infra.Data.MySql.Contexts
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
