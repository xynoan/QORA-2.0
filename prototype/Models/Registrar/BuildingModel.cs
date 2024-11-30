using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prototype.Models.Registrar
{
    public class BuildingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure this is set
        public int BUILDING_ID { get; set; } // Change type to int if not already
        public string? BUILDING_NAME { get; set; } // Change type to int if not already
        public string? BUILDING_CODE { get; set; } // Change type to int if not already
        public string? ROOM_NO { get; set; } // Change type to int if not already
        public string? ROOM_AVAILABLE_SLOT { get; set; } // Change type to int if not already
        public string? CURRENT_SECTION { get; set; } // Change type to int if not already
        public string? MAXIMUM_CAPACITY { get; set; } // Change type to int if not already

      
    }
}
