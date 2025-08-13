using System.Linq.Expressions;

namespace PermissionProject.Abstractions.IRepositories
{
    public interface IGenericRepository<T>
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
        public Task<bool> ExistsAsync(int id);
    }
}
