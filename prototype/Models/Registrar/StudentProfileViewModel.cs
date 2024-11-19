namespace prototype.Models.Registrar
{
    public class StudentProfileViewModel
    {
        public string PhotoUrl { get; set; }       // From STUDENT_ENLISTMENT (ID picture as byte[])
        public string FullName { get; set; }      // Full name derived from PERSONAL_INFORMATION (First, Middle, Last)
        public string Email { get; set; }         // From USER (Email)
        public string Status { get; set; }        // From USER (Status)
        public string StudentId { get; set; }     // Student ID, used for other actions (edit, etc.)
        public string YearLevelTerm { get; set; }     // Year Level, if needed
        public string? Gwa { get; set; }
        public string ReferenceNumber { get; set; } // From StudentReferences (REFERENCE_NUMBER)

    }

}
