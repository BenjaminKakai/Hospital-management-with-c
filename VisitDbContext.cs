using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Audit.EntityFramework;
using DanpheEMR.ServerModel;

namespace DanpheEMR.DalLayer
{
    public class VisitDbContext : AuditDbContext
    {
        public VisitDbContext(DbContextOptions<VisitDbContext> options) : base(options) { }

        public DbSet<VisitModel> Visits { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<BillingTransactionModel> BillingTransactions { get; set; }
        public DbSet<BillingTransactionItemModel> BillingTransactionsItems { get; set; }
        public DbSet<LabRequisitionModel> LabRequisitions { get; set; }
        public DbSet<ImagingRequisitionModel> RadiologyImagingRequisitions { get; set; }
        public DbSet<BillInvoiceReturnModel> BillReturns { get; set; }
        public DbSet<CountrySubDivisionModel> CountrySubdivisions { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<ServiceDepartmentModel> ServiceDepartments { get; set; }
        public DbSet<VitalsModel> Vitals { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<AdmissionModel> Admissions { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<BillItemPrice> BillItemPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
            modelBuilder.Entity<AdmissionModel>().ToTable("ADT_PatientAdmission");

            modelBuilder.Entity<VisitModel>()
                .HasOne<PatientModel>(a => a.Patient)
                .WithMany(a => a.Visits)
                .HasForeignKey(s => s.PatientId);

            modelBuilder.Entity<AdmissionModel>()
                .HasOne<VisitModel>(a => a.Visit)
                .WithOne(a => a.Admission)
                .HasForeignKey<AdmissionModel>(a => a.PatientVisitId);

            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
            modelBuilder.Entity<BillItemPrice>().ToTable("BIL_CFG_BillItemPrice");
            modelBuilder.Entity<LabRequisitionModel>().ToTable("LAB_TestRequisition");
            modelBuilder.Entity<ServiceDepartmentModel>().ToTable("BIL_MST_ServiceDepartment");
            modelBuilder.Entity<BillingTransactionModel>().ToTable("BIL_TXN_BillingTransaction");
            modelBuilder.Entity<BillingTransactionItemModel>().ToTable("BIL_TXN_BillingTransactionItems");
            modelBuilder.Entity<ImagingRequisitionModel>().ToTable("RAD_PatientImagingRequisition");

            modelBuilder.Entity<BillingTransactionItemModel>()
                .HasOne<BillingTransactionModel>(s => s.BillingTransaction)
                .WithMany(s => s.BillingTransactionItems)
                .HasForeignKey(s => s.BillingTransactionId);

            modelBuilder.Entity<BillInvoiceReturnModel>().ToTable("BIL_TXN_InvoiceReturn");
            modelBuilder.Entity<CountrySubDivisionModel>().ToTable("MST_CountrySubDivision");
            modelBuilder.Entity<CountryModel>().ToTable("MST_Country");
            modelBuilder.Entity<VitalsModel>().ToTable("CLN_PatientVitals");
        }
    }
}

