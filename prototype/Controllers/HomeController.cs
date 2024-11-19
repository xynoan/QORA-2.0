using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prototype.Data;
using prototype.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace prototype.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Settings()
        {
            var studentAccId = HttpContext.Session.GetString("ACC_STUDENT_ID");

            if (string.IsNullOrEmpty(studentAccId))
            {
                return RedirectToAction("Index", "Login"); // Redirect if no session data
            }

            var user = _context.Users.FirstOrDefault(u => u.ACC_STUDENT_ID == studentAccId);
            var personalInfo = _context.PERSONAL_INFORMATION.FirstOrDefault(p => p.P_STUDENT_ACC_ID == studentAccId);
            var studentEnlistment = _context.STUDENT_ENLISTMENT.FirstOrDefault(e => e.SEF_STUDENT_ACC_ID == studentAccId);

            if (user == null || personalInfo == null || studentEnlistment == null)
            {
                return RedirectToAction("Index", "Login"); // Redirect if data is missing
            }

            string fullName = $"{personalInfo.FIRST_NAME} {personalInfo.MIDDLE_NAME} {personalInfo.LAST_NAME}";
            string profileImage = null;
            if (studentEnlistment?.SEF_ID_PICTURE != null)
            {
                profileImage = $"data:image/jpeg;base64,{Convert.ToBase64String(studentEnlistment.SEF_ID_PICTURE)}";
            }

            ViewBag.ProfileImage = profileImage;
            ViewBag.FullName = fullName;
            ViewBag.Email = user.EMAIL ?? "Email not found";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Settings(IFormFile SEF_ID_PICTURE, string oldPassword, string newPassword, string confirmNewPassword)
        {
            var studentAccId = HttpContext.Session.GetString("ACC_STUDENT_ID");

            if (string.IsNullOrEmpty(studentAccId))
            {
                return RedirectToAction("Index", "Login"); // Redirect if no session data
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.ACC_STUDENT_ID == studentAccId);
            var studentEnlistment = await _context.STUDENT_ENLISTMENT.FirstOrDefaultAsync(e => e.SEF_STUDENT_ACC_ID == studentAccId);

            if (user == null || studentEnlistment == null)
            {
                return RedirectToAction("Index", "Login"); // Redirect if user or enlistment data is missing
            }

            // Verify if the old password is correct
            if (oldPassword != user.PASSWORD)
            {
                ModelState.AddModelError("OldPassword", "The old password is incorrect.");
                return View();
            }

            // Validate new password and confirmation
            if (newPassword != confirmNewPassword)
            {
                ModelState.AddModelError("PasswordMismatch", "New passwords do not match.");
                return View();
            }

            // Update password if valid
            if (!string.IsNullOrEmpty(newPassword))
            {
                user.PASSWORD = newPassword; // Store the new password (remember to hash passwords in a real scenario)
            }

            // Handle profile picture upload (stored as binary data in the database)
            if (SEF_ID_PICTURE != null && SEF_ID_PICTURE.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await SEF_ID_PICTURE.CopyToAsync(memoryStream);
                    studentEnlistment.SEF_ID_PICTURE = memoryStream.ToArray(); // Store image as binary data in the database
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the profile page or show success message
            TempData["SuccessMessage"] = "Profile updated successfully.";
            return RedirectToAction("Settings");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
