using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Models.EF
{
    public class SurgeryDepartmentDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public SurgeryDepartmentDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Disease> Diseases { get; set; }
        public IDbSet<DiseaseSymptom> DiseasesSymptoms { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<PatientDisease> PatientDiseases { get; set; }
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<Service> Services { get; set; }
        public IDbSet<Symptom> Symptoms { get; set; }
        public IDbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(u => new {u.RoleId, u.UserId});

            modelBuilder.Entity<IdentityRole>()
                .HasKey<string>(r => r.Id);

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Patient>()
                .HasRequired(u => u.Room)
                .WithMany(u => u.Patients)
                .HasForeignKey(u => u.RoomId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Service>()
                .HasKey(u => new {u.RoomId, u.EmployeeId});

            modelBuilder.Entity<PatientDisease>()
                .HasKey(u => new {u.PatientId, u.DiseaseId});


            modelBuilder.Entity<DiseaseSymptom>()
                .HasKey(u => new { u.DiseaseId, u.SymptomId });
        }

        public static SurgeryDepartmentDbContext Create()
        {
            return new SurgeryDepartmentDbContext();
        }

    }
}