using Microsoft.AspNetCore.Mvc;
using prototype.Data;
using prototype.Models;
using prototype.Models.Register;
using System.Text.Json;

namespace prototype.Controllers
{
    [Route("Register")]
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public RegisterController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: Basic Info form
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Basic Info form
        [HttpPost("Index")]
        public IActionResult Index(BasicInformation model)
        {
            if (ModelState.IsValid)
            {
                TempData["BasicInfo"] = JsonSerializer.Serialize(model);
                TempData["StudentAccId"] = model.BI_STUDENT_ACC_ID;
                TempData.Keep("StudentAccId");
                return RedirectToAction("PersonalInfo");
            }
            return View(model);
        }

        // GET: Personal Information form
        [HttpGet("PersonalInfo")]
        public IActionResult PersonalInfo()
        {
            return View();
        }

        // POST: Personal Information form
        [HttpPost("PersonalInfo")]
        public IActionResult PersonalInfo(PersonalInformation model)
        {
            if (ModelState.IsValid)
            {
                model.P_STUDENT_ACC_ID = TempData["StudentAccId"]?.ToString();
                TempData["PersonalInfo"] = JsonSerializer.Serialize(model);
                TempData.Keep("StudentAccId");
                return RedirectToAction("Education");
            }
            return View(model);
        }

        // GET: Education form
        [HttpGet("Education")]
        public IActionResult Education()
        {
            return View();
        }

        // POST: Education form
        [HttpPost("Education")]
        public IActionResult Education(Educations model)
        {
            if (ModelState.IsValid)
            {
                model.E_STUDENT_ACC_ID = TempData["StudentAccId"]?.ToString();
                TempData["Education"] = JsonSerializer.Serialize(model);
                TempData.Keep("StudentAccId");
                return RedirectToAction("Family");
            }
            return View(model);
        }

        // GET: Family form
        [HttpGet("Family")]
        public IActionResult Family()
        {
            return View();
        }

        // POST: Family form
        [HttpPost("Family")]
        public IActionResult Family(Family model)
        {
            if (ModelState.IsValid)
            {
                model.F_STUDENT_ACC_ID = TempData["StudentAccId"]?.ToString();
                TempData["Family"] = JsonSerializer.Serialize(model);
                TempData.Keep("StudentAccId");
                return RedirectToAction("Emergency");
            }
            return View(model);
        }

        // GET: Emergency Contact form
        [HttpGet("Emergency")]
        public IActionResult Emergency()
        {
            return View();
        }

        // POST: Emergency Contact form
        [HttpPost("Emergency")]
        public IActionResult Emergency(EmergencyContact model)
        {
            if (ModelState.IsValid)
            {
                model.PICOE_STUDENT_ACC_ID = TempData["StudentAccId"]?.ToString();
                TempData["Emergency"] = JsonSerializer.Serialize(model);
                TempData.Keep("StudentAccId");
                return RedirectToAction("Create");
            }
            return View(model);
        }

        // GET: Account Creation form
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account Creation and OTP generation
        [HttpPost("Create")]
        public IActionResult Create(AccountCreationModel model)
        {
            if (ModelState.IsValid)
            {
                model.AccStudentId = TempData["StudentAccId"]?.ToString();
                TempData["AccountCreation"] = JsonSerializer.Serialize(model);
                TempData.Keep("StudentAccId");

                // Generate and send OTP
                string otp = GenerateOtp();
                model.Otp = otp;
                HttpContext.Session.SetString("Otp", otp);
                _emailService.SendAccountCreationEmail(model.Email, otp);

                return RedirectToAction("Verification", new { email = model.Email });
            }
            return View(model);
        }


        // GET: Verification page
        [HttpGet("Verification")]
        public IActionResult Verification(string email)
        {
            ViewBag.Email = email;
            return View();
        }
        [HttpPost("Verification")]
        public IActionResult Verification(string[] otp)
        {
            string enteredOtp = string.Join("", otp);
            string storedOtp = HttpContext.Session.GetString("Otp");

            if (enteredOtp == storedOtp)
            {
                var basicInfo = JsonSerializer.Deserialize<BasicInformation>(TempData["BasicInfo"]?.ToString());
                var personalInfo = JsonSerializer.Deserialize<PersonalInformation>(TempData["PersonalInfo"]?.ToString());
                var education = JsonSerializer.Deserialize<Educations>(TempData["Education"]?.ToString());
                var family = JsonSerializer.Deserialize<Family>(TempData["Family"]?.ToString());
                var emergencyContact = JsonSerializer.Deserialize<EmergencyContact>(TempData["Emergency"]?.ToString());
                var accountCreation = JsonSerializer.Deserialize<AccountCreationModel>(TempData["AccountCreation"]?.ToString());

                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    if (basicInfo != null) _context.BASIC_INFORMATION.Add(basicInfo);
                    if (personalInfo != null) _context.PERSONAL_INFORMATION.Add(personalInfo);
                    if (education != null) _context.EDUCATION.Add(education);
                    if (family != null) _context.FAMILY.Add(family);
                    if (emergencyContact != null) _context.PERSON_INCASEOF_EMERGENCY.Add(emergencyContact);

                    if (accountCreation != null)
                    {
                        accountCreation.Status = "Active"; // Set verified status
                        _context.Accounts.Add(accountCreation);
                    }

                    _context.SaveChanges();
                    transaction.Commit();

                    ClearTempData();

                    return RedirectToAction("Registered");
                }
                catch
                {
                    transaction.Rollback();
                    ModelState.AddModelError("", "An error occurred while saving your data. Please try again.");
                    return View();
                }
            }

            // Invalid OTP
            ViewBag.OtpErrorMessage = "Invalid OTP. Please try again.";
            TempData["Email"] = HttpContext.Request.Form["email"];

            return View();
        }


        // GET: Registration complete
        [HttpGet("Registered")]
        public IActionResult Registered()
        {
            return View();
        }

        [HttpPost("ResendOtp")]
        public IActionResult ResendOtp(string email)
        {
            string otp = GenerateOtp();
            HttpContext.Session.SetString("Otp", otp);
            _emailService.SendAccountCreationEmail(email, otp);
            return Json(new { message = "OTP has been resent to your email." });
        }

        private string GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void ClearTempData()
        {
            TempData.Remove("BasicInfo");
            TempData.Remove("PersonalInfo");
            TempData.Remove("Education");
            TempData.Remove("Family");
            TempData.Remove("Emergency");
            TempData.Remove("AccountCreation");
            TempData.Remove("StudentAccId");
        }
    }
}
