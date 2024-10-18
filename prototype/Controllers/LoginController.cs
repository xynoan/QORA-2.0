using Microsoft.AspNetCore.Mvc;

namespace prototype.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
