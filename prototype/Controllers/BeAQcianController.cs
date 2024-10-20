using Microsoft.AspNetCore.Mvc;

namespace prototype.Controllers
{
    public class BeAQcianController : Controller
    {
        // Action method for Data Privacy Notice
        public IActionResult Dpn()
        {
            ViewBag.Title = "Data Privacy Notice";
            ViewBag.CustomHeadingStyle = "text-uppercase";

            ViewBag.DynamicContent = @"
        <h3>PART 1. POLICY </h3>
<p>1. At Quezon City University, we are committed to protecting the privacy and security of the personal data that we gather from the students, parents, guardians, and staff. This privacy notice describes how we gather, use, disclose, and protect personal information in compliance with relevant laws and rules.  
<br><br>
2. Sensitive and personal information are both in the concept of personal data. These are essentially personal identification details.
<br><br>
 3. Any actions, or series of activities, carried out on personal data, such as data collection, recording, organization, preservation, maintenance or modification, retrieval, inquiry, usage, integration, blocking, ensure or destruction, is referred to as a process or processing. </p>
<h3>PART ll. PERSONAL DATA</h3>
<p>4. Details are given voluntarily by students, parents, guardians, or staff when registering, enrolling or communicating with the School. <br><br>
 5. When you enroll or apply at QCU, We collect personal information such as:<br><br>

(1)   Your Name;<br>
(2)  Your Address; <br>
(3)  Your Sex assigned at birth;<br>
(4)  Your Date of Birth;<br>
(5)  Your Citizenship;<br>
(6)  Your Photograph or Image;<br>
(7)  Your Signature;<br>
(8)  Information about your Health Information (for educational and administrative purposes).<br>
(9)  Information about your Education and Educational records. <br>
(10) Information about your Family (Names of your parents, their citizenship, etc.)<br>
(11)  Your choice of QCU campuses and degree programs. <br><br>

    6. These details are needed to confirm your identity, assess whether you’re qualified for QCU enrollment,  
         and record your agreement or authorization for the processing of your personal data while evaluating  
         your ability for QCU enrollment. <br><br>

    7. The following objectives are pursued in the collection of personal data:<br><br>

• Student registration and Enrollment<br>
• Planning and evaluating education <br>
• Interaction with parents/guardians<br>
• Administration and Operations in schools<br>
• Adherence to legal requirements<br><br>

  8. Personal Data gathered during the transfer of student records from educational authorities or other institutions and data
         produced by QCU via administrative procedures, evaluations, or academic assessments. <br><br>

     9. QCU processes your contact information so they can get in touch with you efficiently. </p>
<h3>PART lll. DISCLOSURES</h3>
<p> 10. Within the school, personal information is only used for administrative and instructional purposes. Without express authorization, 
we do not utilize personal information for other advertising or other commercial purposes. <br><br>

11. Personal Information may be shared with the following parties:<br><br>

• Authorities in education for the purpose of reporting compliance<br>
• Service providers that the school has hired to deliver essential services<br>
• Other parties as mandated by law or with parental/guardian consent<br><br>

12. With parental or guardian approval or as mandated by law, personal information may be shared with service providers,  
educational authorities, and other parties. <br><br>

13. QORA or Quezon City University Online Registration Appointment may share the applicants information with third parties 
involved in the application evaluation process, such as admissions committees, faculty members, and relevant administrative 
staff. </p>
<h3>PART lV. PROTECTION</h3>
<p>  14.  Personal Information is only kept for as long as is required by law or to fulfill the objectives for which it was obtained. Data is
hidden or safely disposed away after it is no longer needed. <br><br>

15. We put in place the proper organizational and technical protection to protect against unauthorized access, disclosure,
modification, and destruction of personal data. Only authorized officials are permitted to have access to personal data. </p>
<h3>PART V. ACCESS, CORRECTION AND RIGHTS</h3>
<p> 16. Students have the right to view their personal information and request repairs if they find any errors and they have the right to
object to the processing of their personal data. <br><br>

17. Written requests for access, changes, or deletions of personal information should be made to school administration.<br><br> 

18. Take note that all applicants must submit information that is accurate, full, and true. If you need to update your information,  
refer to the relevant QCU guidelines for other details.  </p>
    <h3>PART Vl. CONSENT</h3>
    <p>  19. By requesting you to complete the appropriate form, QCU gets your consent to process your personal data in accordance with 
    this privacy notice. We will need your parent or legal guardian to sign the appropriate form if you are a minor. <br><br> 

20. Students agree to the collection, use, and processing of their personal data as described in this notice by enrolling or applying 
    at Quezon City University.<br><br>   21. Keep in mind that permission or consent can only be withdrawn from processing activities if consent is the primary legal basis 
    for the processing. Please wait for the response to your request from the Admission Office. </p>
        <h3>PART Vll. QUERIES</h3>
<p>      22. For any inquiries, concerns, or requests about how personal information is handled or about this privacy notice, you may 
contact or get in touch through the following:<br><br>

(1) via post<br><br>

673 Quirino Highway, Novaliches,
Quezon City, Metro Manila<br><br>

(2) via landline<br><br>

286819135<br><br>

(3) via email<br><br>

osas@qcu.edu.ph </p>";

            return View();
        }


        // Action method for General Admission Policy
        public IActionResult Gap()
        {
            ViewBag.Title = "GENERAL ADMISSION POLICY";
            ViewBag.DynamicContent = @"
<p>A student desiring to enroll in Quezon City University
                has to comply with the following
                Admission
                requirements: <br> <br>

                1. Must pass the QCU Admission Test <br>
                2. Must have at least a general weighted average of 80% or above for those who will take BSIT, BSENT,
                and BSIE. For ESA, BSECE, and BECED, see their respective admission policy. <br>
                3. Of good moral character<br>
                4. Physically and Mentally fit to pursue a college education<br>
                5. Must be a senior high school graduate, high school graduate (old curriculum), or ALS passer<br>
                eligible for college<br>
                6. Must pass the department interview</p>";
            return View(); // This will render Views/BeAQcian/Gap.cshtml
        }

        // Action method for Selection for a Degree Program and Campus
        public IActionResult Sdc()
        {
            ViewBag.Title = "SELECTION FOR A DEGREE PROGRAM AND CAMPUS";
            ViewBag.DynamicContent = @"
<p>Qualified applicants for a given campus are ranked
                according to their ratings
                and the available slots of their preferred program. <br><br>

                Applicants who do not qualify for their first choice of Degree Program or Campus will be channeled to
                their
                second or third choice depending on the availability of slots.<br><br>

                Once admitted and enrolled at QCU, you are not allowed to enroll in any other degree program at another
                university.</p>";
            return View(); // This will render Views/BeAQcian/Sdc.cshtml
        }

        // Action method for Freshmen Admission Requirements
        public IActionResult Far()
        {
            ViewBag.Title = "FRESHMEN ADMISSION REQUIREMENTS";
            ViewBag.DynamicContent = @"
<p>Choose if you are Graduating Senior High School Student,
                    a SHS Graduate, High School Graduate. ALS Passers applicants can now register without F138 / REPORT
                    CARD
                    on the condition that they will submit their grades to complete their application for evaluation.
                </p>
                <div class=""row row-cols-2 p-3"">
                    <div class=""col text-center fw-bold border-end border-black border-1"">
                        <h3>BS ENTREP, BSIT, BSIE</h3>
                    </div>
                    <div class=""col text-center fw-bold"">
                        <h3>BSA, BSECE, BECED</h3>
                    </div>
                    <div class=""col border-end border-black border-1"">1. Fully accomplished QCU College Admission
                        Application Form with 2x2 picture
                        (white background
                        with name tag) and am.x Signature of Student over Printed Name on the space provided at the back
                        of the form.<br><br>
                    </div>
                    <div class=""col"">1. Fully accomplished QCU College Admission Application Form with 2x2 picture
                        (white background with name tag) and am.x Signature of Student over Printed Name on the space
                        provided at the back of the form.</div>
                    <div class=""col border-end border-black border-1"">
                        2. <span class=""fw-bold"">SF9 / Report Card / TOR / ALS Certificate</span><br>
                        (Front and Back Clear Copy)<br>
                        (Depends on their Admission Classification)<br><br>
                        • <span class=""fw-bold"">SHS Graduating this July</span><br>
                        Grade 12 2nd Qtr.<br><br>
                        • <span class=""fw-bold"">SHS Graduate</span><br>
                        SF9 12<br><br>
                        • <span class=""fw-bold"">HS Graduate</span><br>
                        Report Card<br><br>
                        • <span class=""fw-bold"">Transferee</span><br>
                        TOR (Complete Grades)<br><br>
                        • <span class=""fw-bold"">ALS Graduate</span><br>
                        ALS Certificate of Rating
                    </div>
                    <div class=""col"">
                        2. <span class=""fw-bold"">SF9 / Report Card / TOR / ALS Certificate</span><br>
                        (Front and Back Clear Copy)<br>
                        (Depends on their Admission Classification)<br><br>
                        • <span class=""fw-bold"">SHS Graduating this July</span><br>
                        Grade 12 2nd Qtr.<br><br>
                        • <span class=""fw-bold"">SHS Graduate</span><br>
                        SF9 12<br><br>
                        • <span class=""fw-bold"">HS Graduate</span><br>
                        Report Card<br><br>
                        • <span class=""fw-bold"">Transferee</span><br>
                        TOR (Complete Grades)<br><br>
                        • <span class=""fw-bold"">ALS Graduate</span><br>
                        ALS Certificate of Rating
                    </div>
                </div>
                <p class=""fw-bold text-center mt-3"">Note: Admissions of Transferees
                    depends on the
                    availability of slots</p>";
            return View(); // This will render Views/BeAQcian/Far.cshtml
        }

        // Action method for QCUCAT Procedure
        public IActionResult Qcucat()
        {
            ViewBag.Title = "QCUCAT PROCEDURE";
            ViewBag.DynamicContent = @"
<h3>Step 1</h3>
                <p>Register using the newly created g-mail account and upload the requirements below in the QCU College
                    Admission Test (QCUCAT) Application Link. Remember your password because this will be used for
                    receiving
                    notifications about the status of your application, invite for department interview, for Admission
                    and
                    Enrollment purposes. You will be using this email for your entire stay at QCU.</p>
                <h3>Step 2</h3>
                <p> The Admissions Office will evaluate the applicants according to the completeness of their submitted
                    requirements. Applicants with complete requirements will be endorsed to the Guidance Office for the
                    schedule of examination.</p>
                <h3>Step 3</h3>
                <p> The Guidance Office will notify the applicants one week ahead of their scheduled examination through
                    their registered email address indicating their schedule of examination with primary instructions
                    together with the Google Meet link. Please check your email\'s spam/junk folder also where our email
                    might be redirected.</p>
                <h3>Step 4</h3>
                <p> QCU CAT Passers will be referred to the Dean of their 1st preferred course for an interview and the
                    results will be sent to the admissions office. (Examinees are advised to check their registered
                    email or
                    your contact numbers for the schedule of the interview.)</p>
                <h3>Step 5</h3>
                <p> A list of qualified students for Admission will be posted on June 2024, at qcu.edu.ph. Students will
                    be
                    informed to submit all the original hard copies of the documentary requirements indicated at the
                    back of
                    the QCU Admission Application Form to secure their enrollment slot. Submission will be via courier,
                    Drop
                    Boxes at the gate, or they will be given an appointment to submit their requirements. <br><br>

                    Requirements should be sealed in a long brown envelope with a list of documents to be
                    submitted.<br><br>

                    Passing the entrance examination does not guarantee enrollment at QCU, passers must submit complete
                    admission requirements to secure a slot for enrollment.</p>";
            return View(); // This will render Views/BeAQcian/Qcucat.cshtml
        }

        // Action method for Admissions Guidelines: Classification
        public IActionResult Agc()
        {
            ViewBag.Title = "ADMISSIONS GUIDELINES: Classifications";
            ViewBag.DynamicContent = @"
<h3>1. FRESHMEN</h3>
                <p>
                    a. High School Graduates (2015 and below) or Senior High School Graduates who must not have enrolled
                    in
                    any academic or college subject/s prior to their enrollment as new college freshmen. <br>
                    b. Students enrolled in 6 months and below vocational courses.<br>
                    c. Alternative Learning System Passers (ALS)<br><br>
                </p>
                <h3>2. TRANSFEREES (admission of transferees are subject to the availability of slots)</h3>
                <p> a. Students who have enrolled in any course leading to a degree program before enrollment in
                    QCU.<br>
                    b. Students who graduated from any I or 2 years Technical Vocational Courses.<br>
                    c. 2nd Degree Course Taker (already a graduate of a Bachelor\'s Degree is not eligible to
                    CHED-UniFAST)</p>";
            return View(); // This will render Views/BeAQcian/Agc.cshtml
        }

        // Action method for Admissions Guidelines: Qualification
        public IActionResult Agq()
        {
            ViewBag.Title = "ADMISSIONS GUIDELINES: Qualifications";
            ViewBag.DynamicContent = @"
<h3>BACHELOR OF SCIENCE IN ACCOUNTANCY (BSA)</h3>
                <div class=""row row-cols-2 p-3 my-4"">
                    <div class=""col text-center fw-bold border-end border-black border-1"">
                        <h4>IF SHS GRADUATE</h3>
                    </div>
                    <div class=""col text-center fw-bold"">
                        <h4>IF TRANSFEREE</h3>
                    </div>
                    <div class=""col border-end border-black border-1"">1. Must have a general weighted average not lower
                        than 90% in Senior High School.<br>
                        2. Must have grades not lower than 90% in the following Senior High School subjects:<br>
                        A. General Mathematics<br>
                        B. English for Academic and Professional Purposes<br>
                        C. Reading and Writing Skills<br>
                        3. Must have a general weighted average not lower than 90%
                        in QCU College Admission Test.
                    </div>
                    <div class=""col"">1. Must have no grades lower than 88% or 2.0 in all his/her subjects. <br>
                        2. Must have a general weighted average not lower than 90% in QCU College Admission Test.<br>
                        3. Must pass the interview and/or examination administered by the Dean (CPA) or Program Chair
                        who will recommend for admission.</div>
                </div>
                <h3>BACHELOR OF SCIENCE IN ELECTRONIC ENGINEERING (BSECE)</h3>
                <div class=""row row-cols-2 p-3 my-4"">
                    <div class=""col text-center fw-bold border-end border-black border-1"">
                        <h4>IF SHS GRADUATE</h4>
                    </div>
                    <div class=""col text-center fw-bold"">
                        <h4>IF TRANSFEREE</h4>
                    </div>
                    <div class=""col border-end border-black border-1"">1. Must have a general weighted average not lower
                        than 90% in Senior High School.<br>
                        2. Must have grades not lower than 90% in the following Senior High School subjects:<br>
                        A. General Mathematics<br>
                        B. English for Academic and Professional Purposes<br>
                        C. Reading and Writing Skills<br>
                        3. Must have a general weighted average not lower than 90%
                        in QCU College Admission Test.
                    </div>
                    <div class=""col"">1. Must have no grades lower than 88% or 2.0 in all his/her subjects. <br>
                        2. Must have a general weighted average not lower than 90% in QCU College Admission Test.<br>
                        3. Must pass the interview and/or examination administered by the Dean (CPA) or Program Chair
                        who will recommend for admission.</div>
                </div>
                <h3>BACHELOR OF EARLY CHILDHOOD EDUCATION (BCEd)</h3>
                <div class=""row row-cols-2 p-3 mt-4"">
                    <div class=""col text-center fw-bold border-end border-black border-1"">
                        <h4>IF SHS GRADUATE</h4>
                    </div>
                    <div class=""col text-center fw-bold"">
                        <h4>IF TRANSFEREE</h4>
                    </div>
                    <div class=""col border-end border-black border-1"">1. Must have a general weighted average not lower
                        than 90% in Senior High School.<br>
                        2. Must have grades not lower than 90% in the following Senior High School subjects:<br>
                        A. General Mathematics<br>
                        B. English for Academic and Professional Purposes<br>
                        C. Reading and Writing Skills<br>
                        3. Must have a general weighted average not lower than 90%
                        in QCU College Admission Test.
                    </div>
                    <div class=""col"">1. Must have no grades lower than 88% or 2.0 in all his/her subjects. <br>
                        2. Must have a general weighted average not lower than 90% in QCU College Admission Test.<br>
                        3. Must pass the interview and/or examination administered by the Dean (CPA) or Program Chair
                        who will recommend for admission.</div>";
            return View(); // This will render Views/BeAQcian/Agq.cshtml
        }

        // Action method for Program Curriculum
        public IActionResult Pc()
        {
            ViewBag.Title = "Program Curricculum";
            ViewBag.CustomHeadingStyle = "text-uppercase";
            ViewBag.CustomDetailsStyle = "rounded-4 border border-black m-3";
            ViewBag.DynamicContent = $@"<embed src=""{Url.Content("~/COURSE_CURRICULUM.pdf")}"" width=""1010"" height=""590"" 
type=""application/pdf"">";
            return View(); // This will render Views/BeAQcian/Pc.cshtml
        }

        // Action method for Grading System
        public IActionResult Gs()
        {
            ViewBag.Title = "GRADING SYSTEM";
            ViewBag.DynamicContent = @"
<table class=""table table-bordered text-center"">
                    <thead>
                        <tr>
                            <th scope=""col"">GRADES</th>
                            <th scope=""col"">EQUIVALENT GRADE</th>
                            <th scope=""col"">GRADE</th>
                            <th scope=""col"">EQUIVALENT GRADE</th>
                            <th scope=""col"">REMARKS</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>98 - 100</td>
                            <td>1.0</td>
                            <td>83 - 85</td>
                            <td>2.25</td>
                            <td>INC - INCOMPLETE</td>
                        </tr>
                        <tr>
                            <td>95 - 97</td>
                            <td>1.25</td>
                            <td>80 - 82</td>
                            <td>2.50</td>
                            <td>OD - OFFICIALLY DROPPED</td>
                        </tr>
                        <tr>
                            <td>92 -94</td>
                            <td>1.50</td>
                            <td>77 - 79</td>
                            <td>2.75</td>
                            <td>UD - UNOFFICIALLY DROPPED</td>
                        </tr>
                        <tr>
                            <td>89 - 91</td>
                            <td>1.75</td>
                            <td>75 - 76</td>
                            <td>3.0</td>
                            <td>OW - OFFICIALLY WITHDRAWN</td>
                        </tr>
                        <tr>
                            <td>86 -88</td>
                            <td>2.00</td>
                            <td>Below 75</td>
                            <td>5.0</td>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
                <p>A student must be officially enrolled in the subjects he/she is attending in, to earn credits.
                    Otherwise, no credit shall be given to him/her. Further, any student of such cases, upon knowledge
                    of faculty concerned and the Registrar shall be dealt with the proper investigation and
                    administrative sanction. Moreover, a student is not allowed to enroll subjects with pre-requisite/s,
                    if he/she has incurred a 5.0 grade in the pre-requisite subjects. Whereas, graduating students are
                    allowed to have overload subjects of not more than six (6) units.</p>
                <h4>ABSENCES</h4>
                <p>A student who incurs absences of more than 20% of the prescribed number of classes or laboratory
                    period during the semester shall fail and earn no credit for the course or subject. Approved
                    absences shall not be counted against the maximum allowable
                </p>
                <h4>DROPPING OF SUBJECTS</h4>
                <p>
                    A student who wishes to officially drop a subject may so a week before the midterm examination.
                    Otherwise, dropping Of subjects beyond the stipulated period will not be entertained. In a case
                    where the student does not witfully attend his/her registered subjects in the current semester,
                    these subjects will be given 5.O
                </p>
                <h4>INCOMPLETE GRADES (INC)</h4>
                <p>Incomplete subjects should be completed within one (1) school year starting the date of recording the
                    INC grade by the Registrar. Otherwise, INC will automatically be rated 5.0. A student with INC is
                    allowed to enroll in the succeeding semester before filling out a completion form duly issued by the
                    Registrar.</p>
                <h4>FAILED GRADE (5.0)</h4>
                <p>A student who fails in three (3) academic subjects (9 units or equivalent) shall be subjected to
                    academic probation and shall be allowed to enroll in no more than fifteen (15) units. If a student
                    on academic probation fails in any of his/her subjects he/she shall be disqualified to study further
                    from the University. However, if the student passed all his/her subjects he/she shall be removed
                    from the academic probation and be allowed to enroll full load.</p>
                <h4>GRADUATION</h4>
                <p>Only students who have COMPLETED an requirements for graduation shall be allowed to graduate. These
                    requirements include PE and NSTP subjects. Students who complete ther course requirements during the
                    summer term or the first semester shall be included in the next regular graduation rites. Only
                    students who APPLY for during the designated application shall be included in the official list of
                    Candidates for Graduaton and the yearbook for the academic year.</p>
                <h4>WITHDRAWAL Of ENROLLMENT</h4>
                <p>A student may be charged for all school fees in full if he/she withdraws any time after the 2nd week
                    of classes</p>";
            return View(); // This will render Views/BeAQcian/Gs.cshtml
        }

        public IActionResult Ba()
        {
            ViewBag.Title = "Batasan Campus";
            ViewBag.CustomHeadingStyle = "text-uppercase";
            ViewBag.DynamicContent = @"
<div class=""d-flex justify-content-between"">
    <div>
        <h3>Address</h3>
        <p>Batasan Rd, Quezon City, Metro Manila</p>
        <h3>Office Hours</h3>
        <p>Monday - Friday <br>
        8:00 am - 5:00pm</p>
    </div>
    <div>
      <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3859.4146000065934!2d121.09164927413423!3d14.689130574905032!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3397ba10f0871a5d%3A0x99b9946d1b3b0bf6!2sQuezon%20City%20University%20-%20Batasan%20Campus!5e0!3m2!1sen!2sph!4v1711593351500!5m2!1sen!2sph"" width=""600"" height=""300"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>
    </div>
</div>
<img src=""/images/ba.png"" width=""1060px""/>";
            return View();
        }

        public IActionResult Contacts()
        {
            ViewBag.Title = "Contacts";
            ViewBag.CustomHeadingStyle = "text-uppercase";
            ViewBag.DynamicContent = @"
<h3>Office of VP for Academic Affairs </h3>
<p>DR. BRADFORD ANTONIO C. MARTINEZ <br>
Contact Number: 8806-3324 Email: ovpaa2020@gmail.com</p>
<h3>Chief, Admissions</h3>
<p>MS. ANNIE LOU M. GONZALES <br>
Contact Number: 8681-9135 Email: admission@qcu.edu.ph</p>
<h3>Registrar and Admissions Division </h3>
<p>MS. SHERYL P. MOSTAJO (Registrar) <br>
Contact Number: 8806-3470 Email: registrar@qcu.edu.ph</p>
<h3>Student Affairs Division </h3>
<p>MS. MERLY P. DELA CRUZ <br>
Contact Number: 8806-3165 Email: sasd2020@gmail.com</p>";
            return View();
        }

        public IActionResult Po()
        {
            ViewBag.Title = "Programs Offered";
            ViewBag.CustomHeadingStyle = "text-uppercase";
            ViewBag.DynamicContent = @"
<h3>College of Business and Accountancy  </h3>
<p>BS in Accountancy <br>
BS in Entrepreneurship <br>
BS of Management Accounting </p>
<h3>College of Computer Studies</h3>
<p>BS in Computer Science <br>
BS in Information Systems <br>
BS in Information Technology</p>
<h3>College of Education</h3>
<p> Bachelor of Early Childhood Education</p>
<h3>College of Engineering </h3>
<p>  BS in Electronics Engineering <br>
BS in Industrial Engineering </p>";
            return View();
        }

        public IActionResult Sb()
        {
            ViewBag.Title = "San Bartolome Campus";
            ViewBag.CustomHeadingStyle = "text-uppercase";
            ViewBag.DynamicContent = @"
<div class=""d-flex justify-content-between"">
    <div>
        <h3>Address</h3>
        <p>673 Quirino Highway, San Bartolome <br>
        Novaliches, Quezon City, Metro Manila</p>
        <h3>Office Hours</h3>
        <p>Monday - Friday <br>
        8:00 am - 5:00pm</p>
    </div>
    <div>
      <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3859.224002421617!2d121.02995897413442!3d14.699920674639237!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3397b0d899095555%3A0x523cb309be95e9a6!2sQuezon%20City%20University!5e0!3m2!1sen!2sph!4v1711592418554!5m2!1sen!2sph"" width=""600"" height=""300"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>
    </div>
</div>
<img src=""../../images/sb.png"" width=""1060px""/>";
            return View();
        }

        public IActionResult Sf()
        {
            ViewBag.Title = "San Francisco Campus";
            ViewBag.CustomHeadingStyle = "text-uppercase";
            ViewBag.DynamicContent = @"
<div class=""d-flex justify-content-between"">
    <div>
        <h3>Address</h3>
        <p>Bago Bantay, Quezon City, Metro Manila</p>
        <h3>Office Hours</h3>
        <p>Monday - Friday <br>
        8:00 am - 5:00pm</p>
    </div>
    <div>
        <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3859.953615762785!2d121.02715309999999!3d14.6585738!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3397b6e48fb74557%3A0x261bc7c2ff5c141!2sQuezon%20City%20University%20-%20San%20Francisco!5e0!3m2!1sen!2sph!4v1711592969324!5m2!1sen!2sph"" width=""600"" height=""300"" style=""border:0;"" allowfullscreen="""" loading=""lazy"" referrerpolicy=""no-referrer-when-downgrade""></iframe>
    </div>
</div>
<img src=""/images/sf.png"" width=""1060px""/>";
            return View();
        }
    }
}
