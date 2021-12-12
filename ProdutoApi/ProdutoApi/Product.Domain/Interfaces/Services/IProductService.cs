using Products.Domain.Dtos;
using Products.Domain.Entites;

namespace Products.Domain.Interfaces.Services
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDto>> GetProducts(CancellationToken token);
        Task<IEnumerable<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task<ProductDto> GetById(long numeroCotacao, CancellationToken cancellationToken);
        Task<ProductDto> Post(ProductPostDto dto, CancellationToken cancellationToken);
        Task<ProductDto> Put(ProductDto dto, CancellationToken cancellationToken);
        Task Delete(long numeroCotacao, CancellationToken cancellationToken);
    }
}
