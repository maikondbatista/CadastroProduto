using Products.Domain.Entites;
using Products.Domain.Interfaces.Repositories;
using Products.Infra.Data.MySql.Contexts;

namespace Products.Infra.Data.MySql
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}
