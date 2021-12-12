using Microsoft.EntityFrameworkCore;
using Categories.Domain.Entites;
using Categories.Infra.Data.MySql.Contexts;

namespace Categories.Domain.Interfaces.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CategoryContext context) : base(context)
        {
        }
    }
}
