using Microsoft.AspNetCore.Mvc;

namespace PermissionProject.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
