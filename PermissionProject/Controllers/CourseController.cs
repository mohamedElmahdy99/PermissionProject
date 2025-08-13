using Microsoft.AspNetCore.Mvc;

namespace PermissionProject.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
