using Microsoft.AspNetCore.Mvc;

namespace ZYX_WEB.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Auth()
        {
            return View();
        }
    }
}
