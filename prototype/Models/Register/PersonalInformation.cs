using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models.Register
{
    public class PersonalInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PERSONAL_INFO_ID { get; set; } // Assuming you want to manage this manually
        public string? FIRST_NAME { get; set; }
        public string? MIDDLE_NAME { get; set; }
        public string? LAST_NAME { get; set; }
        public string? SUFFIX { get; set; }
        public string? DATE_OF_BIRTH { get; set; }
        public string? BIRTH_PLACE { get; set; }
        public string? GENDER { get; set; }
        public string? RELIGION { get; set; }
        public string? CITIZENSHIP { get; set; }
        public string? CIVIL_STATUS { get; set; }
        public string? P_STUDENT_ACC_ID { get; set; }
        public string? BARANGAY { get; set; }
        public string? DISTRICT { get; set; }
        public string? MUNICIPALITY { get; set; }
        public string? STREET { get; set; }
        public string? ZIPCODE { get; set; }
    }

}
