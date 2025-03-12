namespace Infrastructure.Models{
    public class AppointmentCreateModel{
        public int AnimalId {  get; set; }
        public DateTime Date {  get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
