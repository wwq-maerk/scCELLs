using Microsoft.EntityFrameworkCore;
using PatientMedication.Api.Models;

namespace PatientMedication.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<MedicationSchedule> MedicationSchedules => Set<MedicationSchedule>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = 1, Name = "李华", Age = 55, Gender = "男" },
            new Patient { Id = 2, Name = "王芳", Age = 42, Gender = "女" }
        );

        modelBuilder.Entity<MedicationSchedule>().HasData(
            new MedicationSchedule
            {
                Id = 1,
                PatientId = 1,
                DrugName = "阿司匹林",
                Dosage = "100mg",
                Schedule = "每日一次",
                Notes = "餐后服用",
                NextDoseTime = DateTime.UtcNow.AddHours(4)
            }
        );
    }
}
