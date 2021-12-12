using Categories.Domain.Dtos;

namespace Categories.Domain.Interfaces.Services
{
    public interface ICategoryService 
    {
        Task<IEnumerable<CategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryDto> GetById(long id, CancellationToken cancellationToken);
        Task<CategoryDto> Post(CategoryPostDto dto, CancellationToken cancellationToken);
        Task<CategoryDto> Put(CategoryDto dto, CancellationToken cancellationToken);
        Task Delete(long id, CancellationToken cancellationToken);
        Task<bool> DeleteLinkedProducts(long id, string urlProductApi, CancellationToken token);
    }
}
