using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BasicInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure this is set
    public int BASIC_INFO_ID { get; set; } // Change type to int if not already

    public string? ACCREDITATION_OF_SUBJECTS { get; set; }
    public string? APPLICATION_DATE { get; set; }
    public string? APPLYING_AS { get; set; }
    public string BI_STUDENT_ACC_ID { get; set; }
    public string? LRN { get; set; }
    public string? STRAND { get; set; }
    public string? TRACK { get; set; }
    public string? PREFERRED_CAMPUS1 { get; set; }
    public string? PREFERRED_CAMPUS2 { get; set; }
    public string? PREFERRED_CAMPUS3 { get; set; }
    public string? PREFERRED_COURSE1 { get; set; }
    public string? PREFERRED_COURSE2 { get; set; }
    public string? PREFERRED_COURSE3 { get; set; }
    public string? CURRENTLY_ENROLLED { get; set; }
    public string? NAME_OF_SCHOOL { get; set; }
}
