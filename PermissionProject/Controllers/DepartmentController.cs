using Microsoft.AspNetCore.Mvc;
using PermissionProject.Abstractions.IServices;

namespace PermissionProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            if (departments == null || !departments.Any())
            {
                return View("NoDepartments");
            }

            return View(departments);
        }
    }
}
