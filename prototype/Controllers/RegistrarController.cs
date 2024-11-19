using Microsoft.AspNetCore.Mvc;
using prototype.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using prototype.Models.Register;  // For User and PersonalInformation
using prototype.Models.Student;   // For StudentEnlistment and others
using prototype.Models.Registrar;
using prototype.Models;           // For StudentEnlistment and others

namespace prototype.Controllers
{
    public class RegistrarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index Action - List of Students (or any default page)
        public async Task<IActionResult> Index()
        {
            // Retrieve only active students
            var activeStudents = await (from user in _context.Users
                                        join personal in _context.PERSONAL_INFORMATION
                                        on user.ACC_STUDENT_ID equals personal.P_STUDENT_ACC_ID
                                        join enlistment in _context.STUDENT_ENLISTMENT
                                        on user.ACC_STUDENT_ID equals enlistment.SEF_STUDENT_ACC_ID
                                        where user.STATUS == "Active"  // Only active students
                                        select new StudentProfileViewModel
                                        {
                                            // Check if SEF_ID_PICTURE is not null and convert it to Base64 string
                                            PhotoUrl = enlistment.SEF_ID_PICTURE != null && enlistment.SEF_ID_PICTURE.Length > 0
                                                       ? Convert.ToBase64String(enlistment.SEF_ID_PICTURE)
                                                       : string.Empty,
                                            FullName = $"{personal.FIRST_NAME} {personal.MIDDLE_NAME} {personal.LAST_NAME}",
                                            Email = user.EMAIL,
                                            Status = user.STATUS,
                                            StudentId = user.ACC_STUDENT_ID  // Ensure this matches the type (string or int as needed)
                                        }).ToListAsync();

            return View(activeStudents);
        }



        // AddCourse Action - Display Add Course page
        public IActionResult AddCourse()
        {
            return View();
        }

        // Enlist Action - Display Enlist page
        public IActionResult Enlist()
        {
            return View();
        }

        // Printing Action - Display Printing page
        public IActionResult Printing()
        {
            return View();
        }

        // UpdateCourse Action - Display Update Course page
        public IActionResult UpdateCourse()
        {
            return View();
        }

        // UpdateStudent Action - Update student information
        [HttpPost]
        public IActionResult UpdateStudent([FromBody] StudentUpdateModel model)
        {
            // Find the student by ID and update their data
            var student = _context.Users.FirstOrDefault(u => u.ACC_STUDENT_ID == model.StudentId);
            if (student != null)
            {
                var personalInfo = _context.PERSONAL_INFORMATION.FirstOrDefault(p => p.P_STUDENT_ACC_ID == model.StudentId);
                if (personalInfo != null)
                {
                    personalInfo.FIRST_NAME = model.FirstName;
                    personalInfo.MIDDLE_NAME = model.MiddleName;
                    personalInfo.LAST_NAME = model.LastName;
                    student.EMAIL = model.Email;

                    _context.SaveChanges();
                    return Ok("Student updated successfully.");
                }
                return NotFound("Personal information not found.");
            }
            return NotFound("Student not found.");
        }

        // DeleteStudent Action - Delete student by ID
        [HttpPost]
        public IActionResult DeleteStudent([FromForm] string studentId)
        {
            var student = _context.Users.FirstOrDefault(u => u.ACC_STUDENT_ID == studentId);
            if (student != null)
            {
                // If needed, remove related data from other tables
                var personalInfo = _context.PERSONAL_INFORMATION.FirstOrDefault(p => p.P_STUDENT_ACC_ID == studentId);
                if (personalInfo != null)
                {
                    _context.PERSONAL_INFORMATION.Remove(personalInfo);
                }

                // Delete student
                _context.Users.Remove(student);
                _context.SaveChanges();
                return Ok("Student deleted successfully.");
            }
            return NotFound("Student not found.");
        }

        public JsonResult GetStudentDetails(string studentId)
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                return Json(new { message = "Student ID is missing or empty" });
            }

            try
            {
                // Log the input student ID
                Console.WriteLine($"[DEBUG] Searching for Student ID: '{studentId}'");

                // Fetch student details
                var studentDetails = (from user in _context.Users
                                      where user.ACC_STUDENT_ID.Trim() == studentId.Trim() // Match student ID
                                      select new
                                      {
                                          FullName = (from personal in _context.PERSONAL_INFORMATION
                                                      where personal.P_STUDENT_ACC_ID == user.ACC_STUDENT_ID
                                                      select personal.FIRST_NAME + " " + personal.LAST_NAME).FirstOrDefault(),
                                          Status = user.STATUS,
                                          GWA = (from grades in _context.StudentGradings
                                                 where grades.GRADES_STUDENT_ID == user.ACC_STUDENT_ID
                                                 select grades.GWA).FirstOrDefault(),
                                          PhotoUrl = (from enlistment in _context.STUDENT_ENLISTMENT
                                                      where enlistment.SEF_STUDENT_ACC_ID == user.ACC_STUDENT_ID
                                                      select enlistment.SEF_ID_PICTURE != null
                                                          ? "data:image/jpeg;base64," + Convert.ToBase64String(enlistment.SEF_ID_PICTURE)
                                                          : "../../images/default-profile.png").FirstOrDefault(),
                                          YearLevel = (from screening in _context.StudentYrScreenings
                                                       where screening.SYC_STUDENT_ACC_ID == user.ACC_STUDENT_ID
                                                       select screening.YR_LEVEL).FirstOrDefault()
                                      }).FirstOrDefault();

                if (studentDetails != null)
                {
                    Console.WriteLine($"[DEBUG] Student found: {studentDetails.FullName}");
                    return Json(studentDetails);
                }

                Console.WriteLine($"[DEBUG] No student found for ID: '{studentId}'");
                return Json(new { message = "Student not found" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Exception: {ex.Message}");
                return Json(new { message = "An error occurred while fetching student details" });
            }
        }




    }
}
