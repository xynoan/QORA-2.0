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

            // Example dynamic content
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
            return View(); // This will render Views/BeAQcian/Gap.cshtml
        }

        // Action method for Selection for a Degree Program and Campus
        public IActionResult Sdc()
        {
            return View(); // This will render Views/BeAQcian/Sdc.cshtml
        }

        // Action method for Freshmen Admission Requirements
        public IActionResult Far()
        {
            return View(); // This will render Views/BeAQcian/Far.cshtml
        }

        // Action method for QCUCAT Procedure
        public IActionResult Qcucat()
        {
            return View(); // This will render Views/BeAQcian/Qcucat.cshtml
        }

        // Action method for Admissions Guidelines: Classification
        public IActionResult Agc()
        {
            return View(); // This will render Views/BeAQcian/Agc.cshtml
        }

        // Action method for Admissions Guidelines: Qualification
        public IActionResult Agq()
        {
            return View(); // This will render Views/BeAQcian/Agq.cshtml
        }

        // Action method for Program Curriculum
        public IActionResult Pc()
        {
            return View(); // This will render Views/BeAQcian/Pc.cshtml
        }

        // Action method for Grading System
        public IActionResult Gs()
        {
            return View(); // This will render Views/BeAQcian/Gs.cshtml
        }

        public IActionResult Ba()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Po()
        {
            return View();
        }

        public IActionResult Sb()
        {
            return View();
        }

        public IActionResult Sf()
        {
            return View();
        }
    }
}
