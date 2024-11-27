
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prototype.Data;
using prototype.Models;
using prototype.Models.Student;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace prototype.Controllers
{
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }

        [HttpGet("Enrollment")]
        public IActionResult Enrollment()
        {
            // Retrieve ACC_STUDENT_ID from session
            var studentAccId = HttpContext.Session.GetString("ACC_STUDENT_ID");

            if (string.IsNullOrEmpty(studentAccId))
            {
                // If ACC_STUDENT_ID is not found in the session, redirect to login
                return RedirectToAction("Index", "Login");
            }

            // Retrieve user based on ACC_STUDENT_ID to get the email
            var user = _context.Users.FirstOrDefault(u => u.ACC_STUDENT_ID == studentAccId);

            // Retrieve personal information (first name, middle name, last name)
            var personalInfo = _context.PERSONAL_INFORMATION
                                       .FirstOrDefault(p => p.P_STUDENT_ACC_ID == studentAccId);

            // Retrieve the profile picture (varbinary data) for the student
            var studentEnlistment = _context.STUDENT_ENLISTMENT
                                             .FirstOrDefault(e => e.SEF_STUDENT_ACC_ID == studentAccId);

            // Full name construction
            string fullName = "";
            if (personalInfo != null)
            {
                fullName = $"{personalInfo.FIRST_NAME} {personalInfo.MIDDLE_NAME} {personalInfo.LAST_NAME}";
            }

            // Profile picture conversion to Base64 string for display
            string profileImage = null;
            if (studentEnlistment?.SEF_ID_PICTURE != null)
            {
                profileImage = $"data:image/jpeg;base64,{Convert.ToBase64String(studentEnlistment.SEF_ID_PICTURE)}";
            }

            // Pass values to ViewBag
            ViewBag.StudentAccId = studentAccId;
            ViewBag.FullName = fullName;
            ViewBag.Email = user?.EMAIL ?? "Email not found";  // Use null-coalescing if user is null
            ViewBag.ProfileImage = profileImage;

            return View();
        }


        [HttpPost("Enrollment")]
        public async Task<IActionResult> Enrollment(StudentEnlistment model, IFormFile SEF_ID_PICTURE)
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            ModelState.Remove("SEF_ID_PICTURE");

            if (ModelState.IsValid)
            {
                if (SEF_ID_PICTURE != null && SEF_ID_PICTURE.Length > 0)
                {
                    try
                    {
                        // Delete existing enrollment record for this student (if any)
                        var existingEnrollment = _context.STUDENT_ENLISTMENT
                            .FirstOrDefault(e => e.SEF_STUDENT_ACC_ID == accStudentId);
                        if (existingEnrollment != null)
                        {
                            _context.STUDENT_ENLISTMENT.Remove(existingEnrollment);
                        }

                        // Process the uploaded picture
                        using (var memoryStream = new MemoryStream())
                        {
                            await SEF_ID_PICTURE.CopyToAsync(memoryStream);
                            model.SEF_ID_PICTURE = memoryStream.ToArray();
                        }

                        // Associate the current student account ID with the model
                        model.SEF_STUDENT_ACC_ID = accStudentId;

                        // Add the new enrollment record
                        _context.STUDENT_ENLISTMENT.Add(model);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Year");
                    }
                    catch (DbUpdateException ex) when (ex.InnerException != null)
                    {
                        ViewBag.ErrorMessage = $"Database error: {ex.InnerException.Message}";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Please upload a valid image file.";
                }
            }

            return View(model);
        }



        // GET: Year form
        [HttpGet("Year")]
        public IActionResult Year()
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.StudentAccId = accStudentId;
            return View();
        }

        [HttpPost("Year")]
        public async Task<IActionResult> Year(StudentYrScreening model)
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                var existingRecord = await _context.StudentYrScreenings
                    .FirstOrDefaultAsync(y => y.SYC_STUDENT_ACC_ID == accStudentId);

                // Check if APPLYING_AS is "IRREGULAR" or "SHIFTEE" to delete existing grades
                if (model.APPLYING_AS == "IRREGULAR" || model.APPLYING_AS == "SHIFTEE")
                {
                    var gradesToDelete = await _context.StudentGradings
                        .Where(g => g.GRADES_STUDENT_ID == accStudentId)
                        .ToListAsync();

                    if (gradesToDelete.Any())
                    {
                        _context.StudentGradings.RemoveRange(gradesToDelete);
                    }
                }

                // Update or create the year screening record
                if (existingRecord != null)
                {
                    existingRecord.YR_LEVEL = model.YR_LEVEL;
                    existingRecord.YR_TERM = model.YR_TERM;
                    existingRecord.APPLYING_AS = model.APPLYING_AS;
                    existingRecord.ACADEMIC_FROM = model.ACADEMIC_FROM;
                    existingRecord.ACADEMIC_TO = model.ACADEMIC_TO;

                    _context.StudentYrScreenings.Update(existingRecord);
                }
                else
                {
                    model.SYC_STUDENT_ACC_ID = accStudentId;
                    _context.StudentYrScreenings.Add(model);
                }

                await _context.SaveChangesAsync();

                // Redirect based on APPLYING_AS value
                return model.APPLYING_AS == "REGULAR" ? RedirectToAction("Program") : RedirectToAction("ReferenceID");
            }

            return View(model);
        }
    


    // GET: Program form
    [HttpGet("Program")]
        public IActionResult Program()
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.StudentAccId = accStudentId;
            return View();
        }

        [HttpPost("Program")]
        public async Task<IActionResult> Program(StudentYrScreening model)
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                var existingRecord = await _context.StudentYrScreenings
                    .FirstOrDefaultAsync(y => y.SYC_STUDENT_ACC_ID == accStudentId);

                if (existingRecord != null)
                {
                    // Update the Program field in the existing record
                    existingRecord.PROGRAMS_OFFER = model.PROGRAMS_OFFER;
                    _context.StudentYrScreenings.Update(existingRecord);
                }
                else
                {
                    // Redirect to Year if no existing Year record is found
                    return RedirectToAction("Year");
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Grade");
            }

            return View(model);
        }


        // GET: Grade form
        [HttpGet("Grade")]
        public IActionResult Grade()
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            var selectedYearScreening = _context.StudentYrScreenings.FirstOrDefault(y => y.SYC_STUDENT_ACC_ID == accStudentId);
            ViewBag.StudentAccId = accStudentId;

            var subjectData = GetSubjectData();
            Dictionary<string, List<object>> filteredSubjects = null;
            if (selectedYearScreening != null)
            {
                string key = $"{selectedYearScreening.YR_LEVEL?.Trim()}/{selectedYearScreening.YR_TERM?.Trim()}";
                if (subjectData.ContainsKey(key))
                {
                    filteredSubjects = subjectData[key];
                }
            }

            return View(filteredSubjects ?? new Dictionary<string, List<object>>());
        }

        [HttpPost("Grade")]
        public async Task<IActionResult> Grade(Dictionary<string, string> grades, Dictionary<string, string> remarks)
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            var selectedYearScreening = _context.StudentYrScreenings.FirstOrDefault(y => y.SYC_STUDENT_ACC_ID == accStudentId);
            if (selectedYearScreening == null)
            {
                return RedirectToAction("Year");
            }

            var subjectData = GetSubjectData();
            string key = $"{selectedYearScreening.YR_LEVEL?.Trim()}/{selectedYearScreening.YR_TERM?.Trim()}";
            var subjectsForYearSemester = subjectData.ContainsKey(key) ? subjectData[key] : new Dictionary<string, List<object>>();

            // Delete existing grades for this student
            var existingGrades = _context.StudentGradings.Where(g => g.GRADES_STUDENT_ID == accStudentId);
            _context.StudentGradings.RemoveRange(existingGrades);

            // Insert new grades
            var studentGradingList = new List<StudentGrading>();
            double totalUnits = 0;
            double totalGradePoints = 0;

            foreach (var gradeEntry in grades)
            {
                var code = gradeEntry.Key;
                var gradeValue = double.TryParse(gradeEntry.Value, out double grade) ? grade : 0;
                var remark = remarks.ContainsKey(code) ? remarks[code] : "";

                if (subjectsForYearSemester.TryGetValue(code, out var subjectInfo))
                {
                    var subjectName = subjectInfo[0]?.ToString() ?? "";
                    var units = double.TryParse(subjectInfo.Count > 1 ? subjectInfo[1].ToString() : "0", out double u) ? u : 0;

                    totalUnits += units;
                    totalGradePoints += gradeValue * units;

                    studentGradingList.Add(new StudentGrading
                    {
                        GRADES_STUDENT_ID = accStudentId,
                        CODE = code,
                        SUBJECT = subjectName,
                        UNITS = units.ToString(),
                        GRADE = gradeValue.ToString(),
                        REMARKS = remark
                    });
                }
            }

            // Calculate GWA (Grade Weighted Average)
            var gwa = totalUnits > 0 ? totalGradePoints / totalUnits : 0;

            // Round GWA and total units to whole numbers
            var roundedGWA = (int)Math.Round(gwa);
            var roundedTotalUnits = (int)Math.Round(totalUnits);

            // Update each StudentGrading object with the GWA and total units
            foreach (var studentGrade in studentGradingList)
            {
                studentGrade.TOTAL_UNITS = roundedTotalUnits.ToString();
                studentGrade.GWA = roundedGWA.ToString();
            }

            _context.StudentGradings.AddRange(studentGradingList);
            await _context.SaveChangesAsync();

            return RedirectToAction("InputReview");
        }


        // GET: Input Review
        [HttpGet("InputReview")]
        public async Task<IActionResult> InputReview()
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            var studentEnlistment = await _context.STUDENT_ENLISTMENT.FirstOrDefaultAsync(e => e.SEF_STUDENT_ACC_ID == accStudentId);
            var studentYrScreening = await _context.StudentYrScreenings.FirstOrDefaultAsync(y => y.SYC_STUDENT_ACC_ID == accStudentId);
            var studentGrading = await _context.StudentGradings.Where(g => g.GRADES_STUDENT_ID == accStudentId).ToListAsync();

            string imageBase64 = studentEnlistment?.SEF_ID_PICTURE != null
                ? Convert.ToBase64String(studentEnlistment.SEF_ID_PICTURE)
                : null;
            string imageSrc = imageBase64 != null
                ? $"data:image/jpeg;base64,{imageBase64}"
                : null;

            ViewBag.ImageSrc = imageSrc;
            ViewBag.YR_LEVEL = studentYrScreening?.YR_LEVEL ?? "No Year Level Selected";
            ViewBag.YR_TERM = studentYrScreening?.YR_TERM ?? "No Term Selected";
            ViewBag.APPLYING_AS = studentYrScreening?.APPLYING_AS ?? "No Data Selected";
            ViewBag.ACADEMIC_FROM = studentYrScreening?.ACADEMIC_FROM ?? "No Academic From Selected";
            ViewBag.ACADEMIC_TO = studentYrScreening?.ACADEMIC_TO ?? "No Academic To Selected";

            ViewBag.ProgramChosen = studentYrScreening?.PROGRAMS_OFFER ?? "No Program Selected";

            return View(studentGrading);
        }

        [HttpPost("InputReview")]
        public async Task<IActionResult> InputReview(StudentEnlistment enlistmentModel, StudentYrScreening screeningModel, List<StudentGrading> gradingList)
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            // Retrieve current data from the database
            var existingGrades = await _context.StudentGradings.Where(g => g.GRADES_STUDENT_ID == accStudentId).ToListAsync();

            // Update grades if there are changes
            foreach (var grade in gradingList)
            {
                var existingGrade = existingGrades.FirstOrDefault(g => g.CODE == grade.CODE);
                if (existingGrade != null)
                {
                    if (existingGrade.GRADE != grade.GRADE || existingGrade.REMARKS != grade.REMARKS)
                    {
                        existingGrade.GRADE = grade.GRADE;
                        existingGrade.REMARKS = grade.REMARKS;
                    }
                }
                else
                {
                    // Add new grade if it doesn't exist
                    _context.StudentGradings.Add(new StudentGrading
                    {
                        GRADES_STUDENT_ID = accStudentId,
                        CODE = grade.CODE,
                        SUBJECT = grade.SUBJECT,
                        UNITS = grade.UNITS,
                        GRADE = grade.GRADE,
                        REMARKS = grade.REMARKS
                    });
                }
            }

            // Save all changes asynchronously
            await _context.SaveChangesAsync();

            // Redirect to ReferenceID after saving all data
            return RedirectToAction("ReferenceID");
        }


        [HttpGet("ReferenceID")]
        public async Task<IActionResult> ReferenceID()
        {
            var accStudentId = HttpContext.Session.GetString("ACC_STUDENT_ID");
            if (string.IsNullOrEmpty(accStudentId))
            {
                return RedirectToAction("Index", "Login");
            }

            var studentYrScreening = _context.StudentYrScreenings.FirstOrDefault(y => y.SYC_STUDENT_ACC_ID == accStudentId);

            if (studentYrScreening != null)
            {
                int studentCount = _context.Users.Count(u => u.USER_TYPE == "STUDENT");
                string currentYear = DateTime.Now.Year.ToString().Substring(2, 2);
                string department = "CS"; // Adjust department as needed

                string referenceNumber = GenerateStudentCode(
                    currentYear,
                    studentYrScreening.YR_TERM ?? "NO SEMESTER",
                    department,
                    studentYrScreening.PROGRAMS_OFFER ?? "No Program",
                    studentYrScreening.YR_LEVEL ?? "No Year Level",
                    studentCount
                );

                // Insert the generated reference into STUDENT_REFERENCE
                var studentReference = new StudentReference
                {
                    SR_STUDENT_ACC_ID = accStudentId,
                    REFERENCE_NUMBER = referenceNumber,
                    DATE_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Current date and time
                    STATUS = "Active" // Or any default status
                };

                _context.StudentReferences.Add(studentReference);
                await _context.SaveChangesAsync();

                ViewBag.REFERENCE_NUMBER = referenceNumber;
            }

            ViewBag.StudentAccId = accStudentId;
            return View();
        }


        // Generate student code with the provided parameters
        private string GenerateStudentCode(string currentYear, string YR_LEVEL, string department, string program, string YR_TERM, int studentCount)
        {
            return $"{currentYear}{YR_LEVEL}{department}-{program}{YR_TERM}{studentCount:D4}";
        }

      
        // Helper function to generate reference number

        public Dictionary<string, Dictionary<string, List<object>>> GetSubjectData()
        {
            return new Dictionary<string, Dictionary<string, List<object>>>
        {
            { "1/1", new Dictionary<string, List<object>>
                {
                    { "CC102", new List<object> { "Fundamentals of Programming", 3 } },
                    { "GEE1", new List<object> { "Gender and Society", 3 } },
                    { "CC101", new List<object> { "Introduction to Computing", 3 } },
                    { "MATH1", new List<object> { "Mathematics in the Modern World", 3 } },
                    { "NSTP1", new List<object> { "National Service Training Program 1", 3 } },
                    { "GEE2", new List<object> { "People and the Earth's Ecosystems", 3 } },
                    { "PE1", new List<object> { "Physical Fitness and Wellness", 2 } },
                    { "WS101", new List<object> { "Web Systems and Technologies 1 (Electives)", 3 } }
                }
            },
            { "1/2", new Dictionary<string, List<object>>
                {
                    { "CC103", new List<object> { "Intermediate Programming", 3 } },
                    { "NSTP2", new List<object> { "National Service Training Program 2", 3 } },
                    { "NET101", new List<object> { "Networking 1", 3 } },
                    { "GEE3", new List<object> { "Philippine Popular Culture", 3 } },
                    { "PT101", new List<object> { "Platform Technologies (Electives)", 3 } },
                    { "ENG1", new List<object> { "Purposive Communication", 3 } },
                    { "PE2", new List<object> { "Rhythmic Activities", 2 } },
                    { "SCI1", new List<object> { "Science, Technology and Society", 3 } }
                }
            },
            { "2/1", new Dictionary<string, List<object>>
                {
                    { "HUM1", new List<object> { "Art Appreciation", 3 } },
                    { "CC104", new List<object> { "Data Structures and Algorithms", 3 } },
                    { "PE3", new List<object> { "Individual and Dual Sports", 2 } },
                    { "CC105", new List<object> { "Information Management", 3 } },
                    { "NET102", new List<object> { "Networking 2", 2 } },
                    { "PF101", new List<object> { "Object-Oriented Programming", 3 } },
                    { "IS104", new List<object> { "Systems Analysis and Design", 3 } }
                }
            },
            { "2/2", new Dictionary<string, List<object>>
                {
                    { "IM101", new List<object> { "Advanced Database Systems", 3 } },
                    { "IPT101", new List<object> { "Integrative Programming and Technologies 1", 3 } },
                    { "HCI101", new List<object> { "Introduction to Human Computer Interaction", 3 } },
                    { "SOCSCI2", new List<object> { "Readings in Philippine History", 3 } },
                    { "SE101", new List<object> { "Software Engineering", 3 } },
                    { "PE4", new List<object> { "Team Sports", 2 } },
                    { "SOCSCI1", new List<object> { "Understanding the Self", 3 } }
                }
            },
            { "3/1", new Dictionary<string, List<object>>
                {
                    { "AR101", new List<object> { "Architecture and Organization", 3 } },
                    { "MS101", new List<object> { "Discrete Mathematics", 3 } },
                    { "IPT102", new List<object> { "Integrative Programming and Technologies 2 (Electives)", 3 } },
                    { "SPI101", new List<object> { "Social Professional Issues 1", 3 } },
                    { "SIA101", new List<object> { "Systems Integration and Architecture 1", 3 } },
                    { "SOCSCI3", new List<object> { "The Contemporary World", 3 } },
                    { "RIZAL", new List<object> { "The Life and Works of Rizal", 3 } }
                }
            },
            { "3/2", new Dictionary<string, List<object>>
                {
                    { "AL101", new List<object> { "Algorithms and Complexity", 3 } },
                    { "CC106", new List<object> { "Application Development and Emerging Technologies", 3 } },
                    { "HUM2", new List<object> { "Ethics", 3 } },
                    { "IAS101", new List<object> { "Fundamentals of Information Assurance and Security 1", 3 } },
                    { "MS102", new List<object> { "Quantitative Methods", 3 } },
                    { "SIA102", new List<object> { "Systems Integration and Architecture 2 (Electives)", 3 } }
                }
            },
            { "4/1", new Dictionary<string, List<object>>
                {
                    { "AL102", new List<object> { "Automata Theory and Formal Language", 3 } },
                    { "CAP101", new List<object> { "Capstone Project and Research 1", 3 } },
                    { "IAS102", new List<object> { "Information Assurance and Security 2", 3 } },
                    { "PRC101", new List<object> { "Practicum 1", 3 } }
                }
            },
            { "4/2", new Dictionary<string, List<object>>
                {
                    { "CAP102", new List<object> { "Capstone Project and Research 2", 3 } },
                    { "PRC102", new List<object> { "Practicum 2", 3 } },
                    { "SAM101", new List<object> { "Systems Administration and Maintenance", 3 } }
                }
            }
        };

        }
    }
}