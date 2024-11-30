using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using prototype.Models;
using prototype.Models.Register;
using prototype.Models.Student;
using prototype.Data;

namespace prototype.Controllers
{
    public class AccountController : Controller
    {     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Clear the session or sign out the user
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}