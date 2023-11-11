using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.ServerModel.ReportingModels;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DanpheEMR.DalLayer
{
    public class WardReportingDbContext : DbContext
    {
        private string connStr = null;

        public WardReportingDbContext(DbContextOptions<WardReportingDbContext> options) : base(options)
        {
            // If you need to perform any initialization, you can do it here.
        }

        // Define your DbSets here if you decide to use them in the future.
        // Example: public DbSet<YourEntity> YourEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If you have any configurations or mappings, you can define them here.
            // For example: modelBuilder.Entity<YourEntity>().ToTable("YourTableName");
        }

        #region WARD Stock Items Report        
        public DataTable WARDStockItemsReport(int ItemId,int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() { new SqlParameter("@ItemId", ItemId),new SqlParameter("@StoreId", StoreId) };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardReport_StockReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Requisition DataTable
        public DataTable WARDRequisitionReport(DateTime FromDate, DateTime ToDate,int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardReport_RequisitionReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Breakage DataTable
        public DataTable WARDBreakageReport(DateTime FromDate, DateTime ToDate,int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardReport_BreakageReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Consumption DataTable
        public DataTable WARDConsumptionReport(DateTime FromDate, DateTime ToDate,int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardReport_ConsumptionReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Internal Consumption DataTable
        public DataTable WARDInteranlConsumptionReport(DateTime FromDate, DateTime ToDate, int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardReport_InternalConsumptionReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Transfer DataTable
        public DataTable WARDTransferReport(DateTime FromDate, DateTime ToDate,int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardReport_TransferReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Inventory Requisition and Dispatch Report
        public DataTable RequisitionDispatchReport(DateTime FromDate, DateTime ToDate,int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardInv_Report_RequisitionDispatchReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Inventory Transfer Report
        public DataTable TransferReport(DateTime FromDate, DateTime ToDate,int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardInv_Report_TransferReport", paramList, this);
            return stockItems;
        }
        #endregion

        #region WARD Inventory Consumption Report
        public DataTable ConsumptionReport(DateTime FromDate, DateTime ToDate, int StoreId)
        {
            List<SqlParameter> paramList = new List<SqlParameter>() {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate),
                new SqlParameter("@StoreId", StoreId)
            };
            DataTable stockItems = DALFunctions.GetDataTableFromStoredProc("SP_WardInv_Report_ConsumptionReport", paramList, this);
            return stockItems;
        }
        #endregion
    }
}

