using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LarAPP.Api.Data;

namespace LarAPP.src.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _db;

        public Repository(AppDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll(bool trackChanges = false)
        {
            var query = trackChanges ? _db : _db.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _db.FindAsync(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            var query = asNoTracking ? _db.AsNoTracking() : _db;
            return query.Where(predicate).ToList();
        }

        public async Task<T> Create(T entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            if (entity == null)
                return;

            _db.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Add(int id)
        {
            var entity = await _db.FindAsync(id);
            if (entity == null)
                return;

            _db.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
