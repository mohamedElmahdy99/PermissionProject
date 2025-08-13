using PermissionProject.ViewModels.Department;

namespace PermissionProject.Abstractions.IServices
{
    public interface IDepartmentService
    {
        public Task<List<DepartmentShowVM>> GetAllDepartmentsAsync();
        public Task<DepartmentShowVM?> GetDepartmentByIdAsync(int id);
        public Task<DepartmentShowVM?> CreateDepartmentAsync(DepartmentVm department);
        public Task<DepartmentShowVM?> UpdateDepartmentAsync(DepartmentUpdateVm department);
        public Task<bool> DeleteDepartmentAsync(int id);
        public Task<bool> IsDepartmentNameExistsAsync(string name, int? id = null);
    }
}
