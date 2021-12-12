using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Categories.Domain.Entites;

namespace Categories.Infra.Data.MySql.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categoria");

            builder.HasAlternateKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("IdCategoria");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasColumnName("Nome");

        }
    }
}
