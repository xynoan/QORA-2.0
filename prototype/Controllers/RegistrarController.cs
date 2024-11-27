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

        [HttpGet]
        public ActionResult ViewProfiles(string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return RedirectToAction("Index");
            }

            var studentDetails = (from user in _context.Users
                                  join BasicInformation in _context.BASIC_INFORMATION
                                  on user.ACC_STUDENT_ID equals BasicInformation.BI_STUDENT_ACC_ID
                                  join personal in _context.PERSONAL_INFORMATION
                                  on user.ACC_STUDENT_ID equals personal.P_STUDENT_ACC_ID
                                  join Educations in _context.EDUCATION
                                  on user.ACC_STUDENT_ID equals Educations.E_STUDENT_ACC_ID
                                  join Family in _context.FAMILY
                                  on user.ACC_STUDENT_ID equals Family.F_STUDENT_ACC_ID
                                  join EmergencyContact in _context.PERSON_INCASEOF_EMERGENCY
                                  on user.ACC_STUDENT_ID equals EmergencyContact.PICOE_STUDENT_ACC_ID
                                  join enlistment in _context.STUDENT_ENLISTMENT
                                  on user.ACC_STUDENT_ID equals enlistment.SEF_STUDENT_ACC_ID
                                  join screening in _context.StudentYrScreenings
                                  on user.ACC_STUDENT_ID equals screening.SYC_STUDENT_ACC_ID
                                  join grading in _context.StudentGradings
                                  on user.ACC_STUDENT_ID equals grading.GRADES_STUDENT_ID
                                  where user.ACC_STUDENT_ID == studentId
                                  select new StudentDetailsViewModel
                                  {
                    // PersonalInformation /// 
                    FirstName = personal.FIRST_NAME,
                    MiddleName = personal.MIDDLE_NAME,
                    LastName = personal.LAST_NAME,
                    Suffix = personal.SUFFIX,
                    BirthDate = personal.DATE_OF_BIRTH,
                    BirthPlace = personal.BIRTH_PLACE,
                    Citizenship = personal.CITIZENSHIP,
                    Gender = personal.GENDER,
                    Religion = personal.RELIGION,
                    CivilStatus = personal.CIVIL_STATUS,
                    Barangay = personal.BARANGAY,
                    District = personal.DISTRICT,
                    Municipality = personal.MUNICIPALITY,
                    Street = personal.STREET,
                    ZipCode = personal.ZIPCODE,

                    // UserInformation /// 
                    StudentId = user.ACC_STUDENT_ID,

                    // BasicInformation /// 
                    Lrn = BasicInformation.LRN,
                    ApplyingAs = BasicInformation.APPLYING_AS,
                    Application_DATE = BasicInformation.APPLICATION_DATE,

                    // Education /// 

                    CollegeName = Educations.COLLEGE_NAME,
                    CollegeAddress = Educations.C_ADDRESS,
                    CollegeCourseYr = Educations.C_COURSE_YR,
                    CollegeDateGraduated = Educations.C_DATE_GRADUATED,
                    CollegeHonorsReceived = Educations.C_HONORS_RECEIVED,
                    CollegeLocation = Educations.C_LOCATION,
                    CollegeSchoolType = Educations.C_SCHOOL_TYPE,

                    // Family /// 

                    FatherFirstName = Family.FATHER_FIRST_NAME,
                    FatherMiddleName = Family.FATHER_MIDDLE_NAME,
                    FatherLastName = Family.FATHER_LAST_NAME,
                    FatherSuffix = Family.FATHER_SUFFIX,
                    FatherOccupation = Family.FATHER_OCCUPATION,
                    FatherEducationalAttainment = Family.FATHER_EDUCATIONAL_ATTAINMENT,
                    FatherContactNumber = Family.FATHER_CONTACT_NUMBER,

                    MotherFirstName = Family.MOTHER_FIRST_NAME,
                    MotherMiddleName = Family.MOTHER_MIDDLE_NAME,
                    MotherLastName = Family.MOTHER_LAST_NAME,
                    MotherContactNumber = Family.MOTHER_CONTACT_NUMBER,
                    MotherEducationalAttainment = Family.MOTHER_EDUCATIONAL_ATTAINMENT,
                    MotherOccupation = Family.MOTHER_OCCUPATION,

                    FamilyBarangay = Family.FAMILY_BARANGAY,
                    FamilyDistrict = Family.FAMILY_DISTRICT,
                    FamilyMunicipality = Family.FAMILY_MUNICIPALITY,
                    FamilyStreet = Family.FAMILY_STREET,
                    FamilyZipCode = Family.FAMILY_ZIPCODE,

                    GuardianFirstName = Family.GUARDIAN_FIRST_NAME,
                    GuardianMiddleName = Family.GUARDIAN_MIDDLE_NAME,
                    GuardianLastName = Family.GUARDIAN_LAST_NAME,
                    GuardianSuffix = Family.GUARDIAN_SUFFIX,
                    GuardianContactNumber = Family.GUARDIAN_SUFFIX,
                    GuardianRelationship = Family.GUARDIAN_RELATIONSHIP,


                    PicoeFirstName = EmergencyContact.PICOE_FIRSTNAME,
                    PicoeMiddleName = EmergencyContact.PICOE_MIDDLENAME,
                    PicoeLastName = EmergencyContact.PICOE_LASTNAME,
                    PicoeSuffix = EmergencyContact.PICOE_SUFFIX,
                    PicoeContactNumber = EmergencyContact.PICOE_CONTACTNUMBER,
                    PicoeHouseStreet = EmergencyContact.PICOE_HOUSESTREET,
                    PicoeBrgy = EmergencyContact.PICOE_BRGY,
                    PicoeDistrict = EmergencyContact.PICOE_DISTRICT,
                    PicoeMunicipality = EmergencyContact.PICOE_MUNICIPALITY,
                    PicoeZipCode = EmergencyContact.PICOE_ZIPCODE,
                    PicoeRelationship = EmergencyContact.PICOE_RELATIONSHIP,

                                      // StudentScreening /// 
                                      YearLevel = screening.YR_LEVEL,
                    Term = screening.YR_TERM,
                    Academic_FROM = screening.ACADEMIC_FROM,
                    Academic_TO = screening.ACADEMIC_TO,



                    // StudentReference /// 
                    ReferenceNumber = _context.StudentReferences
                        .FirstOrDefault(r => r.SR_STUDENT_ACC_ID == studentId).REFERENCE_NUMBER,

                    // StudentEnlistment /// 
                    PhotoUrl = enlistment.SEF_ID_PICTURE != null && enlistment.SEF_ID_PICTURE.Length > 0
                        ? $"data:image/jpeg;base64,{Convert.ToBase64String(enlistment.SEF_ID_PICTURE)}"
                        : "/images/default-profile.jpg"
                }).FirstOrDefault();


            if (studentDetails == null)
            {
                return NotFound("Student details not found.");
            }

            return View(studentDetails);
        }

        // POST: Save the edited student data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewProfiles(string studentId, StudentDetailsViewModel model)

        {
            if (studentId != model.StudentId)
            {
                return BadRequest("Student ID mismatch.");
            }

            if (ModelState.IsValid)
            {
                var student = await _context.Users
                    .FirstOrDefaultAsync(u => u.ACC_STUDENT_ID == studentId);

                if (student != null)
                {
                    // Update the student's personal information
                    var personalInfo = await _context.PERSONAL_INFORMATION
                        .FirstOrDefaultAsync(p => p.P_STUDENT_ACC_ID == studentId);

                    if (personalInfo != null)
                    {
                        personalInfo.FIRST_NAME = model.FirstName;
                        personalInfo.MIDDLE_NAME = model.MiddleName;
                        personalInfo.LAST_NAME = model.LastName;
                        personalInfo.SUFFIX = model.Suffix;
                        personalInfo.DATE_OF_BIRTH = model.BirthDate;
                        personalInfo.BIRTH_PLACE = model.BirthPlace;
                        personalInfo.CITIZENSHIP = model.Citizenship;
                        personalInfo.GENDER = model.Gender;
                        personalInfo.RELIGION = model.Religion;
                        personalInfo.CIVIL_STATUS = model.CivilStatus;
                        personalInfo.BARANGAY = model.Barangay;
                        personalInfo.DISTRICT = model.District;
                        personalInfo.MUNICIPALITY = model.Municipality;
                        personalInfo.STREET = model.Street;
                        personalInfo.ZIPCODE = model.ZipCode;
                    }

                    // Update Education
                    var education = await _context.EDUCATION
                        .FirstOrDefaultAsync(e => e.E_STUDENT_ACC_ID == studentId);
                    if (education != null)
                    {
                        education.COLLEGE_NAME = model.CollegeName;
                        education.C_ADDRESS = model.CollegeAddress;
                        education.C_COURSE_YR = model.CollegeCourseYr;
                        education.C_DATE_GRADUATED = model.CollegeDateGraduated;
                        education.C_HONORS_RECEIVED = model.CollegeHonorsReceived;
                        education.C_LOCATION = model.CollegeLocation;
                        education.C_SCHOOL_TYPE = model.CollegeSchoolType;
                    }

                    // Update Family Information
                    var family = await _context.FAMILY
                        .FirstOrDefaultAsync(f => f.F_STUDENT_ACC_ID == studentId);
                    if (family != null)
                    {
                        family.FATHER_FIRST_NAME = model.FatherFirstName;
                        family.FATHER_MIDDLE_NAME = model.FatherMiddleName;
                        family.FATHER_LAST_NAME = model.FatherLastName;
                        family.FATHER_SUFFIX = model.FatherSuffix;
                        family.FATHER_OCCUPATION = model.FatherOccupation;
                        family.FATHER_EDUCATIONAL_ATTAINMENT = model.FatherEducationalAttainment;
                        family.FATHER_CONTACT_NUMBER = model.FatherContactNumber;
                        // Similarly for Mother and Guardian
                        family.MOTHER_FIRST_NAME = model.MotherFirstName;
                        family.MOTHER_MIDDLE_NAME = model.MotherMiddleName;
                        family.MOTHER_LAST_NAME = model.MotherLastName;
                        family.MOTHER_CONTACT_NUMBER = model.MotherContactNumber;
                        family.MOTHER_EDUCATIONAL_ATTAINMENT = model.MotherEducationalAttainment;
                        family.MOTHER_OCCUPATION = model.MotherOccupation;

                        // Update Family Address
                        family.FAMILY_BARANGAY = model.FamilyBarangay;
                        family.FAMILY_DISTRICT = model.FamilyDistrict;
                        family.FAMILY_MUNICIPALITY = model.FamilyMunicipality;
                        family.FAMILY_STREET = model.FamilyStreet;
                        family.FAMILY_ZIPCODE = model.FamilyZipCode;

                        family.GUARDIAN_FIRST_NAME = model.GuardianFirstName;
                        family.GUARDIAN_MIDDLE_NAME = model.GuardianMiddleName;
                        family.GUARDIAN_LAST_NAME = model.GuardianLastName;
                        family.GUARDIAN_SUFFIX = model.GuardianSuffix;
                        family.GUARDIAN_CONTACT_NUMBER = model.GuardianContactNumber;
                        family.GUARDIAN_RELATIONSHIP = model.GuardianRelationship;
                    }

                    // Update Emergency Contact Information
                    var emergencyContact = await _context.PERSON_INCASEOF_EMERGENCY
                        .FirstOrDefaultAsync(e => e.PICOE_STUDENT_ACC_ID == studentId);
                    if (emergencyContact != null)
                    {
                        emergencyContact.PICOE_FIRSTNAME = model.PicoeFirstName;
                        emergencyContact.PICOE_MIDDLENAME = model.PicoeMiddleName;
                        emergencyContact.PICOE_LASTNAME = model.PicoeLastName;
                        emergencyContact.PICOE_SUFFIX = model.PicoeSuffix;
                        emergencyContact.PICOE_CONTACTNUMBER = model.PicoeContactNumber;
                        emergencyContact.PICOE_HOUSESTREET = model.PicoeHouseStreet;
                        emergencyContact.PICOE_BRGY = model.PicoeBrgy;
                        emergencyContact.PICOE_DISTRICT = model.PicoeDistrict;
                        emergencyContact.PICOE_MUNICIPALITY = model.PicoeMunicipality;
                        emergencyContact.PICOE_ZIPCODE = model.PicoeZipCode;
                        emergencyContact.PICOE_RELATIONSHIP = model.PicoeRelationship;
                    }
                    await _context.SaveChangesAsync();

                    return RedirectToAction("ViewProfiles", new { studentId = studentId });
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Enlist(string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                TempData["ErrorMessage"] = "Student ID is required to enlist.";
                return RedirectToAction("Index");
            }

            var studentDetails = (from user in _context.Users
                                  join personal in _context.PERSONAL_INFORMATION
                                  on user.ACC_STUDENT_ID equals personal.P_STUDENT_ACC_ID
                                  join screening in _context.StudentYrScreenings
                                  on user.ACC_STUDENT_ID equals screening.SYC_STUDENT_ACC_ID
                                  join enlistment in _context.STUDENT_ENLISTMENT
                                 on user.ACC_STUDENT_ID equals enlistment.SEF_STUDENT_ACC_ID
                                  where user.ACC_STUDENT_ID == studentId
                                  select new StudentDetailsViewModel
                                  {
                                      StudentId = user.ACC_STUDENT_ID,
                                      FirstName = personal.FIRST_NAME,
                                      MiddleName = personal.MIDDLE_NAME,
                                      LastName = personal.LAST_NAME,
                                      Suffix = personal.SUFFIX,
                                      YearLevel = screening.YR_LEVEL,
                                      Term = screening.YR_TERM,

                    // StudentEnlistment /// 
                    PhotoUrl = enlistment.SEF_ID_PICTURE != null && enlistment.SEF_ID_PICTURE.Length > 0
                                      ? $"data:image/jpeg;base64,{Convert.ToBase64String(enlistment.SEF_ID_PICTURE)}"
                        : "/images/default-profile.jpg"
                                  }).FirstOrDefault();


            if (studentDetails == null)
            {
                TempData["ErrorMessage"] = "No student found with the provided ID.";
                return RedirectToAction("Index");
            }

            // Format Year Level and Term using FormatYearLevelTerm
            var formattedYearLevelTerm = FormatYearLevelTerm(studentDetails.YearLevel, studentDetails.Term);
            ViewBag.FormattedYearLevelTerm = formattedYearLevelTerm;

            // Get Subject Data for the current Year Level and Term
            var subjectData = GetSubjectData();
            var yearTermKey = $"{studentDetails.YearLevel}/{studentDetails.Term}";
            var subjects = subjectData.ContainsKey(yearTermKey)
                ? subjectData[yearTermKey]
                : new Dictionary<string, List<object>>();

            // Pass both studentDetails and subjects to the view
            ViewBag.Subjects = subjects;
            return View(studentDetails);
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

        public IActionResult Building()
        {
            return View();
        }
        public IActionResult Section()
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
            if (string.IsNullOrEmpty(yrLevel) || string.IsNullOrEmpty(yrTerm))
            {
                return "Year and Term data missing";
            }
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

        private string RandomTime(bool isMajor)
        {
            Random rand = new Random();
            int startHour = rand.Next(7, 18); // Start between 7 AM and 5 PM
            int duration = isMajor ? rand.Next(3, 5) : rand.Next(1, 3); // Major: 3-4 hours, Minor: 1-2 hours
            int endHour = startHour + duration;

            string startSuffix = startHour >= 12 ? "PM" : "AM";
            string endSuffix = endHour >= 12 ? "PM" : "AM";

            // Convert 24-hour to 12-hour format
            int startHour12 = startHour > 12 ? startHour - 12 : startHour;
            int endHour12 = endHour > 12 ? endHour - 12 : endHour;

            return $"{startHour12}:00 {startSuffix} - {endHour12}:00 {endSuffix}";
        }


        public Dictionary<string, Dictionary<string, List<object>>> GetSubjectData()
        {
            return new Dictionary<string, Dictionary<string, List<object>>>
    {
        // 1st Year, 1st Semester
        { "1/1", new Dictionary<string, List<object>>
            {
                { "CC102", new List<object> { "Fundamentals of Programming", 3, "M", RandomTime(true) } },
                { "GEE1", new List<object> { "Gender and Society", 3, "T", RandomTime(false) } },
                { "CC101", new List<object> { "Introduction to Computing", 3, "W", RandomTime(true) } },
                { "MATH1", new List<object> { "Mathematics in the Modern World", 3, "Th", RandomTime(false) } },
                { "NSTP1", new List<object> { "National Service Training Program 1", 3, "F", RandomTime(false) } },
                { "GEE2", new List<object> { "People and the Earth's Ecosystems", 3, "M", RandomTime(false) } },
                { "PE1", new List<object> { "Physical Fitness and Wellness", 2, "T", RandomTime(false) } },
                { "WS101", new List<object> { "Web Systems and Technologies 1 (Electives)", 3, "W", RandomTime(true) } }
            }
        },

        // 1st Year, 2nd Semester
        { "1/2", new Dictionary<string, List<object>>
            {
                { "CC103", new List<object> { "Intermediate Programming", 3, "T", RandomTime(true) } },
                { "NSTP2", new List<object> { "National Service Training Program 2", 3, "M", RandomTime(false) } },
                { "NET101", new List<object> { "Networking 1", 3, "W", RandomTime(true) } },
                { "GEE3", new List<object> { "Philippine Popular Culture", 3, "Th", RandomTime(false) } },
                { "PT101", new List<object> { "Platform Technologies (Electives)", 3, "F", RandomTime(false) } },
                { "ENG1", new List<object> { "Purposive Communication", 3, "T", RandomTime(false) } },
                { "PE2", new List<object> { "Rhythmic Activities", 2, "Th", RandomTime(false) } },
                { "SCI1", new List<object> { "Science, Technology and Society", 3, "F", RandomTime(false) } }
            }
        },

        // 2nd Year, 1st Semester
        { "2/1", new Dictionary<string, List<object>>
            {
                { "HUM1", new List<object> { "Art Appreciation", 3, "M", RandomTime(false) } },
                { "CC104", new List<object> { "Data Structures and Algorithms", 3, "T", RandomTime(true) } },
                { "PE3", new List<object> { "Individual and Dual Sports", 2, "W", RandomTime(false) } },
                { "CC105", new List<object> { "Information Management", 3, "Th", RandomTime(true) } },
                { "NET102", new List<object> { "Networking 2", 2, "F", RandomTime(false) } },
                { "PF101", new List<object> { "Object-Oriented Programming", 3, "M", RandomTime(true) } },
                { "IS104", new List<object> { "Systems Analysis and Design", 3, "T", RandomTime(true) } }
            }
        },

        // 2nd Year, 2nd Semester
        { "2/2", new Dictionary<string, List<object>>
            {
                { "IM101", new List<object> { "Advanced Database Systems", 3, "M", RandomTime(true) } },
                { "IPT101", new List<object> { "Integrative Programming and Technologies 1", 3, "T", RandomTime(true) } },
                { "HCI101", new List<object> { "Introduction to Human Computer Interaction", 3, "W", RandomTime(false) } },
                { "SOCSCI2", new List<object> { "Readings in Philippine History", 3, "Th", RandomTime(false) } },
                { "SE101", new List<object> { "Software Engineering", 3, "F", RandomTime(true) } },
                { "PE4", new List<object> { "Team Sports", 2, "T", RandomTime(false) } },
                { "SOCSCI1", new List<object> { "Understanding the Self", 3, "M", RandomTime(false) } }
            }
        },

        // 3rd Year, 1st Semester
        { "3/1", new Dictionary<string, List<object>>
            {
                { "AR101", new List<object> { "Architecture and Organization", 3, "M", RandomTime(true) } },
                { "MS101", new List<object> { "Discrete Mathematics", 3, "T", RandomTime(false) } },
                { "IPT102", new List<object> { "Integrative Programming and Technologies 2 (Electives)", 3, "W", RandomTime(true) } },
                { "SPI101", new List<object> { "Social Professional Issues 1", 3, "Th", RandomTime(false) } },
                { "SIA101", new List<object> { "Systems Integration and Architecture 1", 3, "F", RandomTime(true) } },
                { "SOCSCI3", new List<object> { "The Contemporary World", 3, "W", RandomTime(false) } },
                { "RIZAL", new List<object> { "The Life and Works of Rizal", 3, "M", RandomTime(false) } }
            }
        },

        // 3rd Year, 2nd Semester
        { "3/2", new Dictionary<string, List<object>>
            {
                { "AL101", new List<object> { "Algorithms and Complexity", 3, "M", RandomTime(true) } },
                { "CC106", new List<object> { "Application Development and Emerging Technologies", 3, "T", RandomTime(true) } },
                { "HUM2", new List<object> { "Ethics", 3, "W", RandomTime(false) } },
                { "IAS101", new List<object> { "Fundamentals of Information Assurance and Security 1", 3, "Th", RandomTime(false) } },
                { "MS102", new List<object> { "Quantitative Methods", 3, "F", RandomTime(false) } },
                { "SIA102", new List<object> { "Systems Integration and Architecture 2 (Electives)", 3, "M", RandomTime(true) } }
            }
        },

        // 4th Year, 1st Semester
        { "4/1", new Dictionary<string, List<object>>
            {
                { "AL102", new List<object> { "Automata Theory and Formal Language", 3, "M", RandomTime(true) } },
                { "CAP101", new List<object> { "Capstone Project and Research 1", 3, "T", RandomTime(true) } },
                { "IAS102", new List<object> { "Information Assurance and Security 2", 3, "W", RandomTime(false) } },
                { "PRC101", new List<object> { "Practicum 1", 3, "Th", RandomTime(false) } }
            }
        },

        // 4th Year, 2nd Semester
        { "4/2", new Dictionary<string, List<object>>
            {
                { "CAP102", new List<object> { "Capstone Project and Research 2", 3, "M", RandomTime(true) } },
                { "PRC102", new List<object> { "Practicum 2", 3, "T", RandomTime(true) } },
                { "SAM101", new List<object> { "Systems Administration and Maintenance", 3, "W", RandomTime(false) } }
            }
        }
    };
        
    }
}
}