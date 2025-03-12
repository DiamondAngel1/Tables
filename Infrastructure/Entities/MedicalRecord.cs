using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infrastructure.Entities{
    [Table("medical_records")]
    public class MedicalRecord{
        [Key]
        public int Id { get; set; }
        public int AnimalId { get; set; }
        [ForeignKey("AnimalId")]
        public Animals Animal { get; set; } = default!;
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; } = null!;
        public string Treatment { get; set; } = string.Empty;
    }
}