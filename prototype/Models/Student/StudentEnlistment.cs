using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype.Models.Student
{
    [Table("STUDENT_ENLISTMENT")]  // Map explicitly to the database table
    public class StudentEnlistment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STUDENT_ENLISTMENT_ID { get; set; }

        public string? SEF_STUDENT_ACC_ID { get; set; }

        public byte[] SEF_ID_PICTURE { get; set; }
    }
}
