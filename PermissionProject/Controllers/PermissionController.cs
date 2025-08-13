using Microsoft.AspNetCore.Mvc;

namespace PermissionProject.Controllers
{
    public class PermissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
