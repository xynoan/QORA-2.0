using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prototype.Data;
using prototype.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace prototype.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;
        private static string? _userEmail;
        private static string? _otpCode;

        public LoginController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
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
                ViewData["Email"] = email;
                return View("Index");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EMAIL == email);

            if (user != null && user.PASSWORD == password)
            {
                // Store the user's ACC_STUDENT_ID in the session
                HttpContext.Session.SetString("ACC_STUDENT_ID", user.ACC_STUDENT_ID);

                return RedirectToAction("Enrollment", "Student");
            }

            ViewData["EmailError"] = "Incorrect email or password.";
            ViewData["Email"] = email;
            return View("Index");
        }
    
        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendOtp(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.EMAIL == email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email not found.");
                return View("Forgot");
            }

            _userEmail = email;
            _otpCode = GenerateOtp();
            _emailService.SendPasswordResetEmail(email, _otpCode);

            return RedirectToAction("Otp", new { email = email });
        }

        public IActionResult Otp(string email)
        {
            ViewBag.Email = email; // Store the email in ViewBag for the view
            return View();
        }

        [HttpPost]
        public IActionResult VerifyOtp(string[] otp)
        {
            string enteredOtp = string.Join("", otp);

            if (enteredOtp == _otpCode)
            {
                return RedirectToAction("Resetpw");
            }

            ModelState.AddModelError("", "Invalid OTP. Please try again.");
            return View("Otp");
        }

        public IActionResult Resetpw()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendOtpAgain()
        {
            if (string.IsNullOrEmpty(_userEmail))
            {
                return Json(new { message = "No email found. Please request an OTP first." });
            }

            _otpCode = GenerateOtp();
            _emailService.SendPasswordResetEmail(_userEmail, _otpCode);

            return Json(new { message = "OTP sent successfully!" });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View("Resetpw");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EMAIL == _userEmail);

            if (user != null)
            {
                user.PASSWORD = newPassword;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Feedback");
        }

       


        private string GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
        
    }

}
