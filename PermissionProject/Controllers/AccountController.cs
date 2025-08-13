using Microsoft.AspNetCore.Mvc;

namespace PermissionProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
