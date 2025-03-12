using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Infrastructure.Entities{
    [Table("customers")]
    public class Customer{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty!;
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty!;
        [StringLength(100)]
        public string Email { get; set; } = string.Empty!;
        public string Address { get; set; } = string.Empty!;
    }
}