using PermissionProject.Abstractions.IRepositories;
using PermissionProject.Models;

namespace PermissionProject.Abstractions.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> StudentRepo { get; }
        IGenericRepository<Course> CourseRepo { get; }
        IGenericRepository<Department> DepartmentRepo { get; }
        IGenericRepository<Student> ManagerRepo { get; }
        Task<int> SaveChangesasync();

    }
}
