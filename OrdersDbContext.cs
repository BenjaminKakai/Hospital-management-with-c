using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;

namespace DanpheEMR.DalLayer
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RadiologyImagingItemModel>().ToTable("RAD_MST_ImagingItem");
            modelBuilder.Entity<LabTestModel>().ToTable("LAB_LabTests");
            modelBuilder.Entity<PHRMItemMasterModel>().ToTable("PHRM_MST_Item");
            modelBuilder.Entity<PHRMStoreStockModel>().ToTable("PHRM_TXN_Stock");
            modelBuilder.Entity<PHRMGenericModel>().ToTable("PHRM_MST_Generic");
            modelBuilder.Entity<EmployeePreferences>().ToTable("EMP_EmployeePreferences");
            modelBuilder.Entity<PHRMGenericDosageNFreqMap>().ToTable("PHRM_MAP_GenericDosaseNFreq");
            modelBuilder.Entity<BillItemPrice>().ToTable("BIL_CFG_BillItemPrice");
            modelBuilder.Entity<ServiceDepartmentModel>().ToTable("BIL_MST_ServiceDepartment");
            modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
            modelBuilder.Entity<BillingTransactionModel>().ToTable("BIL_TXN_BillingTransaction");
            modelBuilder.Entity<WardModel>().ToTable("ADT_MST_Ward");
            modelBuilder.Entity<AdmissionModel>().ToTable("ADT_PatientAdmission");
        }

        public DbSet<RadiologyImagingItemModel> ImagingItems { get; set; }
        public DbSet<LabTestModel> LabTests { get; set; }
        public DbSet<PHRMItemMasterModel> PharmacyItems { get; set; }
        public DbSet<PHRMStoreStockModel> PharmacyStocks { get; set; }
        public DbSet<PHRMGenericModel> PharmacyGenericItems { get; set; }
        public DbSet<EmployeePreferences> EmployeePreferences { get; set; }
        public DbSet<PHRMGenericDosageNFreqMap> GenericDosageMaps { get; set; }
        public DbSet<BillItemPrice> BillItemPrice { get; set; }
        public DbSet<ServiceDepartmentModel> ServiceDepartment { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<BillingTransactionModel> BillingTransactionModels { get; set; }
        public DbSet<WardModel> Wards { get; set; }
        public DbSet<AdmissionModel> Admissions { get; set; }
    }
}

