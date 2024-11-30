using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prototype.Models.Student
{
    [Table("STUDENT_REFERENCE")]
    public class StudentReference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STUDENT_REF_ID { get; set; }
        public string? SR_STUDENT_ACC_ID { get; set; }
        public string? REFERENCE_NUMBER { get; set; }
        public string? DATE_TIME { get; set; }
        public string? STATUS { get; set; }
    }
}
