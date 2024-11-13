using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models.Register
{
    public class EmergencyContact
    {
        [Key] // This attribute marks the property as a primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PICOE_ID { get; set; } // Unique identifier for emergency contact

        public string? PICOE_FIRSTNAME { get; set; }
        public string? PICOE_MIDDLENAME { get; set; }
        public string? PICOE_LASTNAME { get; set; }
        public string? PICOE_SUFFIX { get; set; }
        public string? PICOE_CONTACTNUMBER { get; set; }
        public string? PICOE_HOUSESTREET { get; set; }
        public string? PICOE_BRGY { get; set; }
        public string? PICOE_DISTRICT { get; set; }
        public string? PICOE_MUNICIPALITY { get; set; }
        public string? PICOE_ZIPCODE { get; set; }
        public string? PICOE_RELATIONSHIP { get; set; }
        public string? PICOE_STUDENT_ACC_ID { get; set; } // Link to the student account
    }
}