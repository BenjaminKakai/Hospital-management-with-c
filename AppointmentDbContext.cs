using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;

namespace DanpheEMR.DalLayer
{
    public class AppointmentDbContext : DbContext
    {
        public DbSet<AppointmentModel> Appointments { get; set; }
        public DbSet<VisitModel> Visit { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentModel>().ToTable("PAT_Appointment");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
        }
    }
}

