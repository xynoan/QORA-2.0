using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models.Student
{
    [Table("STUDENT_YR_SCREENING")]

    public class StudentYrScreening
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure this is set
        public int STUDENT_YR_ID { get; set; }
            public string? SYC_STUDENT_ACC_ID { get; set; }
            public string? APPLYING_AS { get; set; }
            public string? ACADEMIC_FROM { get; set; }
            public string? ACADEMIC_TO { get; set; }
            public string? PROGRAMS_OFFER { get; set; }
            public string? YR_LEVEL { get; set; }
            public string? YR_TERM { get; set; }
        }
    }

