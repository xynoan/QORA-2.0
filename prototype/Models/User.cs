using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models
{
  
   
        public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int USERID { get; set; }  // Maps to USERID

        public string? ACC_STUDENT_ID { get; set; }  // Maps to ACC_STUDENT_ID (nullable)

        [EmailAddress]
        public string? EMAIL { get; set; }  // Maps to EMAIL (nullable)
        public string? PASSWORD { get; set; }  // Maps to PASSWORD (nullable)
        public string? ENROLLMENT_STATUS { get; set; }  // Maps to ENROLLMENT_STATUS (nullable)
        public string? OTP { get; set; }  // Maps to OTP (nullable)
        public string? REFERENCE_STATUS { get; set; }  // Maps to REFERENCE_STATUS (nullable)
        public string? STATUS { get; set; }  // Maps to STATUS (nullable)
        public string? USER_TYPE { get; set; }  // Maps to USER_TYPE (nullable)
        public string? VERIFICATION { get; set; }  // Maps to VERIFICATION (nullable)
    }
}