using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DanpheEMR.Jobs.IRDNepal;
using DanpheEMR.ServerModel;

namespace DanpheEMR.Jobs.IRDNepal
{
    class IRDNepalDbContext : DbContext
    {
        public IRDNepalDbContext(DbContextOptions<IRDNepalDbContext> options) : base(options)
        {
        }

        public DbSet<IRD_Common_InvoiceModel> IrdCommonInvoiceSets { get; set; }
        public DbSet<BillingTransactionModel> BillingTransactions { get; set; }
        public DbSet<BillReturnRequestModel> BillReturnRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IRD_Common_InvoiceModel>().ToTable("IRD_Sync_Invoices_Common");
            modelBuilder.Entity<BillingTransactionModel>().ToTable("BIL_TXN_BillingTransaction");
            modelBuilder.Entity<BillReturnRequestModel>().ToTable("BIL_TXN_BillingReturn");
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
        }
    }
}

