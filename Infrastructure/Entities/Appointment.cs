using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infrastructure.Entities{
    [Table("appointments")]
    public class Appointment{
        [Key]
        public int Id { get; set; }
        public int AnimalId { get; set;}
        [ForeignKey("AnimalId")]
        public Animals Animal { get; set; } = default!;
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
