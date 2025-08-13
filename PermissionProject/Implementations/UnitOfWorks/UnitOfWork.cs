using PermissionProject.Abstractions.IRepositories;
using PermissionProject.Abstractions.IUnitOfWorks;
using PermissionProject.Implementations.Repositories;
using PermissionProject.Models;

namespace PermissionProject.Implementations.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDatabase _db;
        public IGenericRepository<Student> StudentRepo { get; private set; }
        public IGenericRepository<Course> CourseRepo { get; private set; }
        public IGenericRepository<Department> DepartmentRepo { get; private set; }
        public IGenericRepository<Student> ManagerRepo { get; private set; }

        public UnitOfWork(ApplicationDatabase db)
        {
            _db = db;
            StudentRepo = new GenericRepository<Student>(_db);
            CourseRepo = new GenericRepository<Course>(_db);
            DepartmentRepo = new GenericRepository<Department>(_db);
            ManagerRepo = new GenericRepository<Student>(_db);
        }

        public async Task<int> SaveChangesasync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
