using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models
{
    [Table("USERS")] // Maps the model to the USERS table
    public class AccountCreationModel
    {
        [Key]
        [Column("USERID")]
        public int AccountId { get; set; } // Unique identifier for the account

        [Column("ACC_STUDENT_ID")]
        public string? AccStudentId { get; set; }

        [Required]
        [EmailAddress]
        [Column("EMAIL")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Column("PASSWORD")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [NotMapped] // This is not mapped to the database, only used for validation
        public string? ConfirmPassword { get; set; }

        [Column("ENROLLMENT_STATUS")]
        public string? EnrollmentStatus { get; set; }

        [Column("STATUS")]
        public string? Status { get; set; }

        [Column("USER_TYPE")]
        public string? UserType { get; set; } // User type field in the database

        [Column("VERIFICATION")]
        public string? Verification { get; set; }
    }
}
