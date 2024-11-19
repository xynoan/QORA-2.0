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
        // Action to view student profile
        public ActionResult ViewProfiles(string studentId)
        {
            ViewBag.StudentId = studentId; // Pass it to the view

            return View();
        }

        // Action to enlist a student
        public ActionResult Enlist()
        {
            return View();
        }

        // Index Action - List of Students (or any default page)
        public async Task<IActionResult> Index()
        {
            // Fetch students who have a record in the StudentReferences table
            var studentsWithReference = await (from user in _context.Users
                                               join personal in _context.PERSONAL_INFORMATION
                                               on user.ACC_STUDENT_ID equals personal.P_STUDENT_ACC_ID
                                               join enlistment in _context.STUDENT_ENLISTMENT
                                               on user.ACC_STUDENT_ID equals enlistment.SEF_STUDENT_ACC_ID
                                               join screening in _context.StudentYrScreenings
                                               on user.ACC_STUDENT_ID equals screening.SYC_STUDENT_ACC_ID
                                               join grading in _context.StudentGradings
                                               on user.ACC_STUDENT_ID equals grading.GRADES_STUDENT_ID
                                               join reference in _context.StudentReferences // Join with StudentReferences to get Reference Number
                                               on user.ACC_STUDENT_ID equals reference.SR_STUDENT_ACC_ID
                                               where reference.SR_STUDENT_ACC_ID != null // Ensure that the student has a reference record
                                               select new
                                               {
                                                   user.ACC_STUDENT_ID,
                                                   personal.FIRST_NAME,
                                                   personal.MIDDLE_NAME,
                                                   personal.LAST_NAME,
                                                   user.EMAIL,
                                                   enlistment.SEF_ID_PICTURE,
                                                   screening.YR_LEVEL,
                                                   screening.YR_TERM,  // Get YR_TERM
                                                   Gwa = grading.GWA,  // Get GWA from StudentGradings
                                                   ReferenceNumber = reference.REFERENCE_NUMBER // Get REFERENCE_NUMBER from StudentReferences
                                               })
                                                .GroupBy(x => x.ACC_STUDENT_ID) // Group by StudentId to ensure only one row per student
                                                .Select(g => g.FirstOrDefault()) // Take the first record from each group
                                                .ToListAsync();

            // Map the result to StudentProfileViewModel
            var studentProfiles = studentsWithReference.Select(student => new StudentProfileViewModel
            {
                PhotoUrl = student.SEF_ID_PICTURE != null && student.SEF_ID_PICTURE.Length > 0
                           ? Convert.ToBase64String(student.SEF_ID_PICTURE)
                           : string.Empty,
                FullName = $"{student.FIRST_NAME} {student.MIDDLE_NAME} {student.LAST_NAME}",
                Email = student.EMAIL,
                StudentId = student.ACC_STUDENT_ID,
                YearLevelTerm = FormatYearLevelTerm(student.YR_LEVEL, student.YR_TERM), // Format the Year Level and Term
                Gwa = student.Gwa, // Include GWA from StudentGradings
                ReferenceNumber = student.ReferenceNumber // Include Reference Number
            }).ToList();

            // Return the data to the view
            return View(studentProfiles);
        }

      
        // AddCourse Action - Display Add Course page
        public IActionResult AddCourse()
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


        // DELETE: /Registrar/DeleteReferenceByStudentId
        [HttpDelete]
        public async Task<IActionResult> DeleteReferenceByStudentId(string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest("Invalid student ID.");
            }

            var reference = await _context.StudentReferences.FirstOrDefaultAsync(r => r.SR_STUDENT_ACC_ID == studentId);
            if (reference == null)
            {
                return NotFound("Reference for the student not found.");
            }

            try
            {
                _context.StudentReferences.Remove(reference);
                await _context.SaveChangesAsync();
                return Ok("Reference deleted successfully.");
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the reference.");
            }
        }

        

        // Helper method to format YearLevel and Term
        private string FormatYearLevelTerm(string yrLevel, string yrTerm)
        {
            // Format Year Level with suffix (st, nd, rd, th)
            string yearSuffix = GetYearSuffix(yrLevel);
            string formattedYrLevel = $"{yrLevel}{yearSuffix} Year";

            // Format YR_TERM (e.g., 1st Semester, 2nd Semester)
            string formattedYrTerm = $"{yrTerm}{GetSemesterSuffix(yrTerm)} Semester";

            // Combine Year Level and Term
            return $"{formattedYrLevel} - {formattedYrTerm}";
        }

        // Helper method to get the suffix for Year Level (st, nd, rd, th)
        private string GetYearSuffix(string yrLevel)
        {
            if (int.TryParse(yrLevel, out int level))
            {
                if (level == 1) return "st";
                else if (level == 2) return "nd";
                else if (level == 3) return "rd";
                else return "th";
            }
            return "th"; // Default to "th" if not a number
        }

        // Helper method to get the suffix for Semester (st, nd)
        private string GetSemesterSuffix(string yrTerm)
        {
            if (int.TryParse(yrTerm, out int term))
            {
                if (term == 1) return "st";
                else if (term == 2) return "nd";
            }
            return ""; // Default if not found
        }


    }
}
