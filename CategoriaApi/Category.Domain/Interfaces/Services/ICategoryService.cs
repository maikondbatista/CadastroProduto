using Categories.Domain.Dtos;

namespace Categories.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseService
    {
        Task<IEnumerable<CategoryBaseDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryBaseDto> GetById(long id, CancellationToken cancellationToken);
        Task<CategoryBaseDto> Post(CategoryPostDto dto, CancellationToken cancellationToken);
        Task<CategoryBaseDto> Put(CategoryBaseDto dto, CancellationToken cancellationToken);
        Task Delete(long id, CancellationToken cancellationToken);
        Task<bool> DeleteLinkedProducts(long id, string urlProductApi, CancellationToken token);
    }
}
