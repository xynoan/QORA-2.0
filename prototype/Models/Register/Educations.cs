using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models.Register
{
    public class Educations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EDUCATION_ID { get; set; }
        public string? E_STUDENT_ACC_ID { get; set; }

        // College properties
        public string? COLLEGE_NAME { get; set; }
        public string? C_ADDRESS { get; set; }
        public string? C_COURSE_YR { get; set; }
        public string? C_DATE_GRADUATED { get; set; }
        public string? C_HONORS_RECEIVED { get; set; }
        public string? C_LOCATION { get; set; }
        public string? C_SCHOOL_TYPE { get; set; }

        // Technical Vocational properties
        public string? TECH_VOC_NAME { get; set; }
        public string? TV_ADDRESS { get; set; }
        public string? TV_COURSE_YR { get; set; }
        public string? TV_DATE_GRADUATED { get; set; }
        public string? TV_HONORS_RECEIVED { get; set; }
        public string? TV_LOCATION { get; set; }
        public string? TV_SCHOOL_TYPE { get; set; }
        public string? TV_CURRICULUM { get; set; }

        // High School properties
        public string? HIGH_SCHOOL_NAME { get; set; }
        public string? HS_ADDRESS { get; set; }
        public string? HS_COURSE_YR { get; set; }
        public string? HS_DATE_GRADUATE { get; set; }
        public string? HS_HONORS_RECEIVED { get; set; }
        public string? HS_LOCATION { get; set; }
        public string? HS_SCHOOL_TYPE { get; set; }
        public string? HS_CURRICULUM { get; set; }
    }

}

