using Products.Domain.Entites.Base;

namespace Products.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Query();
        Task<T> Insert(T obj, CancellationToken token);

        Task<T> Update(T obj, CancellationToken token);

        Task Remove(long id, CancellationToken token);
        Task Remove(object[] key, CancellationToken token);

        Task<T> Find(object[] key, CancellationToken token);
        Task<T> Find(long id, CancellationToken token);

        Task<IEnumerable<T>> GetAll(CancellationToken token);
    }
}
