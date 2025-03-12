using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure{
    public class Context : DbContext{
        public DbSet<Specie> Species { get; set; }
        public DbSet<Animals> Animals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public Context(){}
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseNpgsql("Host=ep-holy-salad-a8m2hg5z-pooler.eastus2.azure.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_6XrNMvb4SPLk");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Appointment>()
                .HasOne(a=>a.Animal)
                .WithMany()
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Animal)
                .WithMany()
                .HasForeignKey(mr => mr.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
