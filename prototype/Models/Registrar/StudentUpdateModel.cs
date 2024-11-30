namespace prototype.Models.Registrar
{
    public class StudentUpdateModel
    {
        public string StudentId { get; set; }   // The student’s unique identifier
        public string FirstName { get; set; }   // The student’s first name
        public string MiddleName { get; set; }  // Optional middle name
        public string LastName { get; set; }    // The student’s last name
        public string Email { get; set; }       // The student’s updated email address
    }
}