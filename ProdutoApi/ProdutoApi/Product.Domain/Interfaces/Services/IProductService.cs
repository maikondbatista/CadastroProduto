using Products.Domain.Dtos;
using Products.Domain.Entites;

namespace Products.Domain.Interfaces.Services
{
    public interface IProductService : IBaseService 
    {
        Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductDto> GetById(long numeroCotacao, CancellationToken cancellationToken);
        Task<ProductDto> Post(ProductPostDto dto, CancellationToken cancellationToken);
        Task<ProductDto> Put(ProductDto dto, CancellationToken cancellationToken);
        Task Delete(long numeroCotacao, CancellationToken cancellationToken);
        Task DeleteByCategoryId(long id, CancellationToken token);
        Task<CategoryDto> CheckCategoryExists(long categoryId, string urlCategoriaApi, CancellationToken token);
    }
}
