using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Infrastructure.Entities{
    [Table("tbl_species")]
    public class Specie{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = null!;
        public ICollection<Animals> Animals { get; set; }
    }
}
