using PermissionProject.Abstractions.IServices;
using PermissionProject.Abstractions.IUnitOfWorks;
using PermissionProject.Models;
using PermissionProject.ViewModels.Department;

namespace PermissionProject.Implementations.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DepartmentShowVM?> CreateDepartmentAsync(DepartmentVm department)
        {
            if (await IsDepartmentNameExistsAsync(department.DepartmentName))
            {
                return null;
            }
            var newDepartment = new Department()
            {
                DepartmentName = department.DepartmentName,
                IsActive = department.IsActive,
                ManagerId = department.ManagerId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,

            };
            await _unitOfWork.DepartmentRepo.AddAsync(newDepartment);

            return new DepartmentShowVM()
            {
                DepartmentId = newDepartment.DepartmentId,
                DepartmentName = newDepartment.DepartmentName,
                IsActive = newDepartment.IsActive,
                ManagerName = newDepartment.Manager?.User?.FirstName + " " + newDepartment.Manager?.User?.LastName ?? "No manager",
                ManagerId = newDepartment.ManagerId,
            };
        }

        public Task<bool> DeleteDepartmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentShowVM>> GetAllDepartmentsAsync()
        {
            var deprtment = await _unitOfWork.DepartmentRepo.GetAllAsync(s => s.IsActive);
            return deprtment.Select(d => new DepartmentShowVM()
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                IsActive = d.IsActive,
                ManagerName = d.Manager?.User?.FirstName + " " + d.Manager?.User?.LastName ?? "No manager",
                ManagerId = d.ManagerId,
            }).ToList();

        }

        public async Task<DepartmentShowVM?> GetDepartmentByIdAsync(int id)
        {

            var department = await _unitOfWork.DepartmentRepo.GetByIdAsync(id);
            if (department == null || !department.IsActive)
                return new DepartmentShowVM();
            var dep = new DepartmentShowVM()
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                IsActive = department.IsActive,
                ManagerName = department.Manager?.User?.FirstName + " " + department.Manager?.User?.LastName ?? "No manager",
                ManagerId = department.ManagerId,
            };
            return dep;
        }

        public async Task<bool> IsDepartmentNameExistsAsync(string name, int? id = null)
        {
            var dept = await _unitOfWork.DepartmentRepo.GetAllAsync(s => s.IsActive && s.DepartmentName == name);
            if (dept.Any())
                return true;
            return false;

        }

        public async Task<DepartmentShowVM> UpdateDepartmentAsync(DepartmentUpdateVm department)
        {
            var departmentUpdate = await _unitOfWork.DepartmentRepo.GetByIdAsync(department.DeptId);
            if (departmentUpdate == null)
            {
                return new DepartmentShowVM();
            }
            departmentUpdate.DepartmentId = department.DeptId;
            departmentUpdate.DepartmentName = department.DepartmentName;
            departmentUpdate.Manager.ManagerId = department.ManagerId;
            departmentUpdate.DepartmentId = department.DeptId;
            departmentUpdate.IsActive = department.IsActive;
            departmentUpdate.UpdatedAt = DateTime.UtcNow;
            departmentUpdate.ManagerId = department.ManagerId;

            await _unitOfWork.DepartmentRepo.UpdateAsync(departmentUpdate);

            return new DepartmentShowVM()
            {
                DepartmentId = departmentUpdate.DepartmentId,
                DepartmentName = departmentUpdate.DepartmentName,
                IsActive = departmentUpdate.IsActive,
                ManagerName = departmentUpdate.Manager?.User?.FirstName + " " + departmentUpdate.Manager?.User?.LastName ?? "No manager",
                ManagerId = departmentUpdate.ManagerId,
            };

        }
    }
}
