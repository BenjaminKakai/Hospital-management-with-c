using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.ServerModel.EmergencyModels;

namespace DanpheEMR.DalLayer
{
    public class EmergencyDbContext : DbContext
    {
        public DbSet<EmergencyPatientModel> EmergencyPatient { get; set; }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<VisitModel> Visits { get; set; }
        public DbSet<CountryModel> Country { get; set; }
        public DbSet<CountrySubDivisionModel> CountrySubDivision { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<AdmissionModel> Admissions { get; set; }
        public DbSet<ServiceDepartmentModel> ServiceDepartment { get; set; }
        public DbSet<BillingTransactionItemModel> BillingTransactionItems { get; set; }
        public DbSet<BillItemPrice> BillItemPrice { get; set; }
        public DbSet<BillingCounter> BillingCounter { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmergencyDischargeSummaryModel> DischargeSummary { get; set; }
        public DbSet<VitalsModel> Vitals { get; set; }
        public DbSet<LabRequisitionModel> LabRequisitions { get; set; }
        public DbSet<ImagingRequisitionModel> ImagingRequisitions { get; set; }
        public DbSet<MembershipTypeModel> MembershipTypes { get; set; }
        public DbSet<PatientMembershipModel> PatientMemberships { get; set; }
        public DbSet<AdminParametersModel> AdminParameters { get; set; }
        public DbSet<ModeOfArrival> ModeOfArrival { get; set; }
        public DbSet<EmergencyPatientCases> PatientCases { get; set; }
        public DbSet<UploadConsentForm> Consentform { get; set; }
        public DbSet<MunicipalityModel> Municipalities { get; set; }

        public EmergencyDbContext(DbContextOptions<EmergencyDbContext> options) : base(options)
        {
            // EF Core doesn't support LazyLoadingEnabled and ProxyCreationEnabled in the same way as EF6.
            // If you need lazy loading in EF Core, you'll need to use the Microsoft.EntityFrameworkCore.Proxies package.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModeOfArrival>().ToTable("ER_ModeOfArrival");
            modelBuilder.Entity<AdminParametersModel>().ToTable("CORE_CFG_Parameters");
            modelBuilder.Entity<EmergencyPatientModel>().ToTable("ER_Patient");
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
            modelBuilder.Entity<CountryModel>().ToTable("MST_Country");
            modelBuilder.Entity<CountrySubDivisionModel>().ToTable("MST_CountrySubDivision");
            modelBuilder.Entity<AdmissionModel>().ToTable("ADT_PatientAdmission");
            modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
            modelBuilder.Entity<VisitModel>()
                   .HasOne<PatientModel>(a => a.Patient)
                   .WithMany(a => a.Visits)
                   .HasForeignKey(s => s.PatientId);
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<ServiceDepartmentModel>().ToTable("BIL_MST_ServiceDepartment");
            modelBuilder.Entity<BillingTransactionItemModel>().ToTable("BIL_TXN_BillingTransactionItems");
            modelBuilder.Entity<BillItemPrice>().ToTable("BIL_CFG_BillItemPrice");
            modelBuilder.Entity<BillingCounter>().ToTable("BIL_CFG_Counter");
            modelBuilder.Entity<EmergencyDischargeSummaryModel>().ToTable("ER_DischargeSummary");
            modelBuilder.Entity<VitalsModel>().ToTable("CLN_PatientVitals");
            modelBuilder.Entity<LabRequisitionModel>().ToTable("LAB_TestRequisition");
            modelBuilder.Entity<ImagingRequisitionModel>().ToTable("RAD_PatientImagingRequisition");
            modelBuilder.Entity<MembershipTypeModel>().ToTable("PAT_CFG_MembershipType");
            modelBuilder.Entity<PatientMembershipModel>().ToTable("PAT_PatientMembership");
            modelBuilder.Entity<EmergencyPatientCases>().ToTable("ER_Patient_Cases");
            modelBuilder.Entity<UploadConsentForm>().ToTable("ER_FileUploads");
            modelBuilder.Entity<MunicipalityModel>().ToTable("MST_Municipality");
        }
    }
}

