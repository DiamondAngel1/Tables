namespace Infrastructure.Models{
    public class AnimalCreateModel{
        public string Name { get; set; } = null!;
        public int SpecieId { get; set; }
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}