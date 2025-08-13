using PermissionProject.Abstractions.IRepositories;
using PermissionProject.Models;
using System.Linq.Expressions;

namespace PermissionProject.Implementations.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDatabase db;
        private readonly DbSet<T> dbset;

        public GenericRepository(ApplicationDatabase _db)
        {
            db = _db;
            dbset = _db.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                dbset.Remove(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbset.AnyAsync(dbset => EF.Property<int>(dbset, "Id") == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await dbset.Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbset.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            db.Update(entity);
        }
    }
}
