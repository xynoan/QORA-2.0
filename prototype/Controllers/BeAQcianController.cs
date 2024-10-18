using Microsoft.AspNetCore.Mvc;

namespace prototype.Controllers
{
    public class BeAQcianController : Controller
    {
        // Action method for Data Privacy Notice
        public IActionResult Dpn()
        {
            return View(); // This will render Views/BeAQcian/Dpn.cshtml
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
