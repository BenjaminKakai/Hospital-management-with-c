using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DanpheEMR.DalLayer
{
    public class FractionDbContext : DbContext
    {
        public DbSet<DesignationModel> Designation { get; set; }
        public DbSet<FractionCalculationModel> FractionCalculation { get; set; }
        public DbSet<BillingTransactionItemModel> BillingTransactionItems { get; set; }
        public DbSet<BillItemPrice> BillItemPrice { get; set; }
        public DbSet<FractionPercentModel> FractionPercent { get; set; }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }

        public FractionDbContext(DbContextOptions<FractionDbContext> options) : base(options)
        {
        }

        // Note: The stored procedure calls have been commented out as EF Core handles stored procedures differently.
        // You'll need to use the `FromSqlRaw` or `FromSqlInterpolated` methods to execute stored procedures in EF Core.

        /*
        public DataTable GetFractionApplicable()
        {
            // Implement using FromSqlRaw or FromSqlInterpolated
        }
        public DataTable GetFractionReportByItemList()
        {
            // Implement using FromSqlRaw or FromSqlInterpolated
        }
        public DataTable GetFractionReportByDoctorList(DateTime FromDate, DateTime ToDate)
        {
            // Implement using FromSqlRaw or FromSqlInterpolated
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesignationModel>().ToTable("FRC_Designation");
            modelBuilder.Entity<FractionPercentModel>().ToTable("FRC_PercentSetting");
            modelBuilder.Entity<BillItemPrice>().ToTable("BIL_CFG_BillItemPrice");
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");

            modelBuilder.Entity<FractionCalculationModel>().ToTable("FRC_FractionCalculation");
            modelBuilder.Entity<BillingTransactionItemModel>().ToTable("BIL_TXN_BillingTransactionItems");
            modelBuilder.Entity<BillItemPrice>().ToTable("BIL_CFG_BillItemPrice");
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");

            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
        }
    }
}

