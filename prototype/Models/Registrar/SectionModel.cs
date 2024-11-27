using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prototype.Models.Registrar
{
    public class SectionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure this is set
        public int SECTION_ID { get; set; } // Change type to int if not already
        public string? SECTION_NAME { get; set; } // Change type to int if not already
        public string? SECTION_SLOT { get; set; } // Change type to int if not already
        public string? MAX_CAPACITY { get; set; } // Change type to int if not already
    }
}
