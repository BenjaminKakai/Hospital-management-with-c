using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;

namespace DanpheEMR.DalLayer
{
    public class RadiologyDbContext : DbContext
    {
        public DbSet<ImagingRequisitionModel> ImagingRequisitions { get; set; }
        public DbSet<ImagingReportModel> ImagingReports { get; set; }
        public DbSet<RadiologyImagingItemModel> ImagingItems { get; set; }
        public DbSet<RadiologyImagingTypeModel> ImagingTypes { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<EmployeePreferences> EmployeePreferences { get; set; }
        public DbSet<RadiologyReportTemplateModel> RadiologyReportTemplate { get; set; }
        public DbSet<BillingTransactionItemModel> BillingTransactionItems { get; set; }
        public DbSet<ServiceDepartmentModel> ServiceSepartments { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<FilmTypeModel> FilmType { get; set; }
        public DbSet<CountrySubDivisionModel> CountrySubDivision { get; set; }
        public DbSet<MunicipalityModel> Muncipality { get; set; }

        public RadiologyDbContext(DbContextOptions<RadiologyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MunicipalityModel>().ToTable("MST_Municipality");
            modelBuilder.Entity<CountrySubDivisionModel>().ToTable("MST_CountrySubDivision");
            modelBuilder.Entity<RadiologyImagingItemModel>().ToTable("RAD_MST_ImagingItem");
            modelBuilder.Entity<RadiologyImagingTypeModel>().ToTable("RAD_MST_ImagingType");
            modelBuilder.Entity<ImagingRequisitionModel>().ToTable("RAD_PatientImagingRequisition");
            modelBuilder.Entity<RadiologyReportTemplateModel>().ToTable("RAD_CFG_ReportTemplates");
            modelBuilder.Entity<ImagingReportModel>().ToTable("RAD_PatientImagingReport");

            modelBuilder.Entity<ImagingRequisitionModel>()
                        .HasOne<VisitModel>(i => i.Visit)
                        .WithMany(v => v.ImagingRequisitions)
                        .HasForeignKey(i => i.PatientVisitId);

            modelBuilder.Entity<ImagingReportModel>()
                        .HasOne<VisitModel>(i => i.Visit)
                        .WithMany(v => v.ImagingReports)
                        .HasForeignKey(i => i.PatientVisitId);

            modelBuilder.Entity<ImagingReportModel>()
                .HasOne(a => a.ImagingRequisition)
                .WithOne(a => a.ImagingReport)
                .HasForeignKey<ImagingReportModel>(a => a.ImagingRequisitionId);

            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
            modelBuilder.Entity<RadiologyImagingItemModel>().ToTable("RAD_MST_ImagingItem");
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<EmployeePreferences>().ToTable("EMP_EmployeePreferences");
            modelBuilder.Entity<BillingTransactionItemModel>().ToTable("BIL_TXN_BillingTransactionItems");
            modelBuilder.Entity<ServiceDepartmentModel>().ToTable("BIL_MST_ServiceDepartment");
            modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
            modelBuilder.Entity<FilmTypeModel>().ToTable("RAD_MST_FilmType");
        }
    }
}

