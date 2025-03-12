namespace Infrastructure.Models{
    public class MedicalRecordCreateModel{
        public int AnimalId { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; } = null!;
        public string Treatment { get; set;} = string.Empty;
    }
}
