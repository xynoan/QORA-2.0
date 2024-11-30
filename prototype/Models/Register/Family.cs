using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models.Register
{
    public class Family
    {
        [Key] // This attribute marks the property as a primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FAMILY_ID { get; set; } // This corresponds to FAMILY_ID in the database

        public string? F_STUDENT_ACC_ID { get; set; }

        public string? FATHER_FIRST_NAME { get; set; }
        public string? FATHER_MIDDLE_NAME { get; set; }
        public string? FATHER_LAST_NAME { get; set; }
        public string? FATHER_SUFFIX { get; set; }
        public string? FATHER_OCCUPATION { get; set; }
        public string? FATHER_EDUCATIONAL_ATTAINMENT { get; set; }
        public string? FATHER_CONTACT_NUMBER { get; set; }

        public string? MOTHER_FIRST_NAME { get; set; }
        public string? MOTHER_MIDDLE_NAME { get; set; }
        public string? MOTHER_LAST_NAME { get; set; }
        public string? MOTHER_CONTACT_NUMBER { get; set; }
        public string? MOTHER_EDUCATIONAL_ATTAINMENT { get; set; }
        public string? MOTHER_OCCUPATION { get; set; }
        public string? FAMILY_BARANGAY { get; set; }
        public string? FAMILY_DISTRICT { get; set; }
        public string? FAMILY_MUNICIPALITY { get; set; }
        public string? FAMILY_STREET { get; set; }
        public string? FAMILY_ZIPCODE { get; set; }

        public string? GUARDIAN_FIRST_NAME { get; set; }
        public string? GUARDIAN_MIDDLE_NAME { get; set; }
        public string? GUARDIAN_LAST_NAME { get; set; }
        public string? GUARDIAN_SUFFIX { get; set; }
        public string? GUARDIAN_CONTACT_NUMBER { get; set; }
        public string? GUARDIAN_RELATIONSHIP { get; set; }

    }
}
