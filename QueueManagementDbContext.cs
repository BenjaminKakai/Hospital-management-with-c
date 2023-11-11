using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanpheEMR.DalLayer
{
    public class QueueManagementDbContext : DbContext
    {
        public QueueManagementDbContext(DbContextOptions<QueueManagementDbContext> options) : base(options)
        {
        }

        public DbSet<DepartmentModel> Department { get; set; }
        public DbSet<VisitModel> Visits { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");

            modelBuilder.Entity<VisitModel>()
                .HasOne<PatientModel>(a => a.Patient)
                .WithMany(a => a.Visits)
                .HasForeignKey(s => s.PatientId);

            modelBuilder.Entity<VisitModel>()
                .HasOne<AdmissionModel>(a => a.Admission)
                .WithOne(a => a.Visit)
                .HasForeignKey<AdmissionModel>(a => a.VisitId); // Assuming AdmissionModel has a VisitId foreign key
        }
    }
}

