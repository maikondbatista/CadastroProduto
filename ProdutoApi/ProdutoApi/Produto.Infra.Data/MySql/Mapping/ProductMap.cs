using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entites;

namespace Products.Infra.Data.MySql.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.HasAlternateKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .HasColumnName("IdProduto");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasColumnName("Nome");

            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnName("Preco")
                   .HasColumnType("float(12,4)");

        }
    }
}
