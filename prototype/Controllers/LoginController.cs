using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prototype.Data;
using System.Linq;
using System.Threading.Tasks;

namespace prototype.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enrollment(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                if (string.IsNullOrEmpty(email))
                {
                    ViewData["EmailError"] = "Please provide an email.";
                }

                if (string.IsNullOrEmpty(password))
                {
                    ViewData["PasswordError"] = "Please provide a password.";
                }

                ViewData["Email"] = email; // Retain email input
                ViewData["Password"] = password; // Retain password input
                return View("Index");
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.EMAIL == email && u.PASSWORD == password);

            if (user != null)
            {
                // Successful login logic (like creating a session)
                return RedirectToAction("Enrollment", "Student"); // Redirect to home or another page
            }
            else
            {
                // Display error message if email or password is incorrect
                ViewData["EmailError"] = "Incorrect email or password.";
                ViewData["Email"] = email; // Retain email input
                ViewData["Password"] = password; // Retain password input
                return View("Index"); // Stay on the login page
            }
        }



        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        public IActionResult Otp()
        {
            return View();
        }

        public IActionResult Resetpw()
        {
            return View();
        }
    }
}
