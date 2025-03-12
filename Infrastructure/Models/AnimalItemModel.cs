namespace Infrastructure.Models{
    public class AnimalItemModel{
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SpecieId { get; set; }
        public string SpecieName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}