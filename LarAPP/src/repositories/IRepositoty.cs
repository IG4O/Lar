using System.Linq.Expressions;

namespace LarAPP.src.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(bool trackChanges = false);
        Task<T> GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task Add(int id);
    }
}