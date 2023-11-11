using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.Security;

namespace DanpheEMR.DalLayer
{
    public class VaccinationDbContext : DbContext
    {
        public VaccinationDbContext(DbContextOptions<VaccinationDbContext> options) : base(options)
        {
        }

        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<AdminParametersModel> AdminParameters { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<CountrySubDivisionModel> CountrySubdivisions { get; set; }
        public DbSet<VaccineMasterModel> VaccineMaster { get; set; }
        public DbSet<PatientVaccineDetailModel> PatientVaccineDetail { get; set; }
        public DbSet<MembershipTypeModel> MembershipTypes { get; set; }
        public DbSet<BillingFiscalYear> BillingFiscalYears { get; set; }
        public DbSet<EthnicGroupModel> EthnicGroupCast { get; set; }
        public DbSet<MunicipalityModel> Municipalities { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<VisitModel> Visits { get; set; }
        public DbSet<RbacUser> RbacUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
            modelBuilder.Entity<AdminParametersModel>().ToTable("CORE_CFG_Parameters");
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<CountrySubDivisionModel>().ToTable("MST_CountrySubDivision");
            modelBuilder.Entity<VaccineMasterModel>().ToTable("VACC_Vaccines");
            modelBuilder.Entity<PatientVaccineDetailModel>().ToTable("VACC_PatientVaccineDetail");
            modelBuilder.Entity<MembershipTypeModel>().ToTable("PAT_CFG_MembershipType");
            modelBuilder.Entity<BillingFiscalYear>().ToTable("BIL_CFG_FiscalYears");
            modelBuilder.Entity<EthnicGroupModel>().ToTable("MST_EthnicGroup");
            modelBuilder.Entity<MunicipalityModel>().ToTable("MST_Municipality");
            modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
            modelBuilder.Entity<RbacUser>().ToTable("RBAC_User");
        }
    }
}

