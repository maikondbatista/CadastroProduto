using Microsoft.EntityFrameworkCore;
using Products.Domain.Entites;
using Products.Infra.Data.MySql.Contexts;
using Produto.Infra.Data.MySql.Repositories;

namespace Products.Domain.Interfaces.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}
