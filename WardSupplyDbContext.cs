using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.ServerModel.InventoryModels;

namespace DanpheEMR.DalLayer
{
    public class WardSupplyDbContext : DbContext
    {
        public WardSupplyDbContext(DbContextOptions<WardSupplyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WardModel>().ToTable("ADT_MST_Ward");
            modelBuilder.Entity<PHRMStoreModel>().ToTable("PHRM_MST_Store");
            modelBuilder.Entity<WARDStockModel>().ToTable("WARD_Stock");
            modelBuilder.Entity<WARDRequisitionModel>().ToTable("WARD_Requisition");
            modelBuilder.Entity<WARDRequisitionItemsModel>().ToTable("WARD_RequisitionItems");
            modelBuilder.Entity<WARDDispatchModel>().ToTable("WARD_Dispatch");
            modelBuilder.Entity<WARDDispatchItemsModel>().ToTable("WARD_DispatchItems");
            modelBuilder.Entity<WARDConsumptionModel>().ToTable("WARD_Consumption");
            modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<EmployeeRoleModel>().ToTable("EMP_EmployeeRole");
            modelBuilder.Entity<PHRMItemMasterModel>().ToTable("PHRM_MST_Item");
            modelBuilder.Entity<PHRMGenericModel>().ToTable("PHRM_MST_Generic");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
            modelBuilder.Entity<AdmissionModel>().ToTable("ADT_PatientAdmission");
            modelBuilder.Entity<PatientBedInfo>().ToTable("ADT_TXN_PatientBedInfo");
            modelBuilder.Entity<WARDTransactionModel>().ToTable("WARD_Transaction");
            modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
            modelBuilder.Entity<WARDInventoryConsumptionModel>().ToTable("WARD_INV_Consumption");
            modelBuilder.Entity<ItemMasterModel>().ToTable("INV_MST_Item");
            modelBuilder.Entity<UnitOfMeasurementMasterModel>().ToTable("INV_MST_UnitOfMeasurement");
            modelBuilder.Entity<WARDInternalConsumptionItemsModel>().ToTable("WARD_InternalConsumptionItems");
            modelBuilder.Entity<WARDInternalConsumptionModel>().ToTable("WARD_InternalConsumption");
            modelBuilder.Entity<PHRMInvoiceTransactionItemsModel>().ToTable("PHRM_TXN_InvoiceItems");
            modelBuilder.Entity<VerificationModel>().ToTable("TXN_Verification");
            modelBuilder.Entity<InventoryFiscalYear>().ToTable("INV_CFG_FiscalYears");
            modelBuilder.Entity<RequisitionModel>().ToTable("INV_TXN_Requisition");
            modelBuilder.Entity<RequisitionItemsModel>().ToTable("INV_TXN_RequisitionItems");
            modelBuilder.Entity<FixedAssetStockModel>().ToTable("INV_TXN_FixedAssetStock");
            modelBuilder.Entity<GoodsReceiptModel>().ToTable("INV_TXN_GoodsReceipt");
            modelBuilder.Entity<GoodsReceiptItemsModel>().ToTable("INV_TXN_GoodsReceiptItems");
            modelBuilder.Entity<FixedAssetDonationModel>().ToTable("INV_MST_Donation");
            modelBuilder.Entity<VendorMasterModel>().ToTable("INV_MST_Vendor");
            modelBuilder.Entity<WARDSupplyAssetRequisitionModel>().ToTable("INV_TXN_FixedAssetRequisition");
            modelBuilder.Entity<WARDSupplyAssetRequisitionItemsModel>().ToTable("INV_TXN_FixedAssetRequisitionItems");
            modelBuilder.Entity<CssdItemTransactionModel>().ToTable("CSSD_TXN_ItemTransaction");
            modelBuilder.Entity<InvPatientConsumptionReceiptModel>().ToTable("[WARD_INV_ConsumptionReceipt]");
            modelBuilder.Entity<WARDSupplyAssetReturnModel>().ToTable("INV_TXN_FixedAssetReturn");
            modelBuilder.Entity<WARDSupplyAssetReturnItemsModel>().ToTable("INV_TXN_FixedAssetReturnItems");
            modelBuilder.Entity<FixedAssetDispatchModel>().ToTable("INV_TXN_FixedAssetDispatch");
            modelBuilder.Entity<FixedAssetDispatchItemsModel>().ToTable("INV_TXN_FixedAssetDispatchItems");
            modelBuilder.Entity<AssetLocationHistoryModel>().ToTable("INV_AssetLocationHistory");
            modelBuilder.Entity<StoreStockModel>().ToTable("INV_TXN_StoreStock");
            modelBuilder.Entity<StockTransactionModel>().ToTable("INV_TXN_StockTransaction");
        }

        public DbSet<WardModel> WardModel { get; set; }
        public DbSet<PHRMStoreModel> StoreModel { get; set; }
        public DbSet<WARDStockModel> WARDStockModel { get; set; }
        public DbSet<WARDRequisitionModel> WARDRequisitionModel { get; set; }
        public DbSet<WARDRequisitionItemsModel> WARDRequisitionItemsModel { get; set; }
        public DbSet<WARDDispatchModel> WARDDispatchModel { get; set; }
        public DbSet<WARDDispatchItemsModel> WARDDispatchItemsModel { get; set; }
        public DbSet<WARDConsumptionModel> WARDConsumptionModel { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeRoleModel> EmployeeRole { get; set; }
        public DbSet<PHRMItemMasterModel> PHRMItemMaster { get; set; }
        public DbSet<PHRMGenericModel> PHRMGenericMaster { get; set; }
        public DbSet<AdmissionModel> Admissions { get; set; }
        public DbSet<VisitModel> Visits { get; set; }
        public DbSet<PatientBedInfo> PatientBedInfos { get; set; }
        public DbSet<WARDTransactionModel> TransactionModel { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<WARDInventoryConsumptionModel> WARDInventoryConsumptionModel { get; set; }
        public DbSet<ItemMasterModel> INVItemMaster { get; set; }
        public DbSet<UnitOfMeasurementMasterModel> UnitOfMeasurementMaster { get; set; }
        public DbSet<WARDInternalConsumptionItemsModel> WARDInternalConsumptionItemsModel { get; set; }
        public DbSet<WARDInternalConsumptionModel> WARDInternalConsumptionModel { get; set; }
        public DbSet<PHRMInvoiceTransactionItemsModel> PHRMInvoiceTransactionItems { get; set; }
        public DbSet<VerificationModel> VerificationModel { get; set; }
        public DbSet<InventoryFiscalYear> InvFiscalYears { get; set; }
        public DbSet<RequisitionModel> Requisitions { get; set; }
        public DbSet<RequisitionItemsModel> RequisitionItems { get; set; }
        public DbSet<FixedAssetStockModel> FixedAssetStock { get; set; }
        public DbSet<GoodsReceiptModel> GoodsReceipts { get; set; }
        public DbSet<GoodsReceiptItemsModel> GoodsReceiptItems { get; set; }
        public DbSet<FixedAssetDonationModel> FixedAssetDonation { get; set; }
        public DbSet<VendorMasterModel> Vendors { get; set; }
        public DbSet<WARDSupplyAssetRequisitionModel> WARDSupplyAssetRequisitionModels { get; set; }
        public DbSet<WARDSupplyAssetRequisitionItemsModel> WARDSupplyAssetRequisitionItemsModels { get; set; }
        public DbSet<CssdItemTransactionModel> CssdItemTransactions { get; set; }
        public DbSet<InvPatientConsumptionReceiptModel> PatientConsumptionReceipt { get; set; }
        public DbSet<WARDSupplyAssetReturnModel> WARDSupplyAssetReturnModels { get; set; }
        public DbSet<WARDSupplyAssetReturnItemsModel> WARDSupplyAssetReturnItemsModels { get; set; }
        public DbSet<FixedAssetDispatchModel> FixedAssetDispatchModels { get; set; }
        public DbSet<FixedAssetDispatchItemsModel> FixedAssetDispatchItemsModels { get; set; }
        public DbSet<AssetLocationHistoryModel> AssetLocationHistory { get; set; }
        public DbSet<StoreStockModel> StoreStocks { get; set; }
        public DbSet<StockTransactionModel> StockTransactions { get; set; }
    }
}

