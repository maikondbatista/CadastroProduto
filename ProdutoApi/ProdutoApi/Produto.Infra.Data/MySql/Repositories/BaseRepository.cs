using Products.Domain.Interfaces.Repositories;
using Products.Domain.Entites.Base;
using Products.Infra.Data.MySql.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Products.Infra.Data.MySql
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ProductContext _context;

        public BaseRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<T> Insert(T obj, CancellationToken token)
        {
            obj.Created = DateTime.Now;
            obj.Updated = DateTime.Now;
            _context.Set<T>().Add(obj);
            await _context.SaveChangesAsync(token);

            return obj;
        }
        public async Task<T> Update(T obj, CancellationToken token)
        {
            obj.Updated = DateTime.Now;
            _context.Update(obj);
            await _context.SaveChangesAsync(token);

            return obj;
        }

        public async Task Remove(object[] key, CancellationToken token)
        {
            T entity = await Find(key, token);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(token);
        }

        public async Task Remove(long id, CancellationToken token)
        {
            T entity = await Find(id, token);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(token);
        }

        public async Task<T> Find(object[] key, CancellationToken token)
        {
            return await _context.Set<T>().FindAsync(key, token);
        }
        public async Task<T> Find(long id, CancellationToken token)
        {
            return await Find(new object[] { id }, token);
        }

        public virtual IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable().AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken token)
        {
            return await Query().ToListAsync(token);
        }

    }
}
