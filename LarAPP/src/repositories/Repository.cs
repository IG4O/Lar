using Microsoft.EntityFrameworkCore;
using Projeto.Api.Data;

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


        public async Task<IEnumerable<T>> GetAll() => await _db.ToListAsync();
        public async Task<T> GetById(int id) => await _db.FindAsync(id);
        public async Task<T> Create(T entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(T entity)
        {
            _db.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var e = await _db.FindAsync(id);
            if (e != null) { _db.Remove(e); await _context.SaveChangesAsync(); }
        }
    }
}
