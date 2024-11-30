using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models
{
    [Table("STUDENT_GRADES")]
    public class StudentGrading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GRADES_ID { get; set; }

        public string? GRADES_STUDENT_ID { get; set; }

        public string? GRADE { get; set; }

        public string? SUBJECT { get; set; }
        
        public string? CODE { get; set; }

        public string? TOTAL_UNITS { get; set; }

        public string? UNITS { get; set; }

        public string? GWA { get; set; }

        public string? REMARKS { get; set; }
    }
}
