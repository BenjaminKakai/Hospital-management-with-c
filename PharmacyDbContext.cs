using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.ServerModel.PharmacyModels;
using DanpheEMR.Security;
using System.Collections.Generic;

namespace DanpheEMR.DalLayer
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) { }

        // DbSet properties sorted alphabetically
        public DbSet<AdminParametersModel> AdminParameters { get; set; }
        public DbSet<BillInvoiceReturnItemsModel> BillInvoiceReturnItemsModel { get; set; }
        public DbSet<BillInvoiceReturnModel> BillInvoiceReturnModel { get; set; }
        public DbSet<CountrySubDivisionModel> CountrySubDivision { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<InsuranceModel> PatientInsurances { get; set; }
        public DbSet<IRDLogModel> IRDLog { get; set; }
        public DbSet<PHRMBillTransactionItem> PHRMBillTransactionItems { get; set; }
        public DbSet<PHRMBillTransactionModel> PHRMBillTransaction { get; set; }
        public DbSet<PHRMCategoryModel> PHRMCategory { get; set; }
        public DbSet<PHRMCompanyModel> PHRMCompany { get; set; }
        public DbSet<PHRMDepositModel> DepositModel { get; set; }
        public DbSet<PHRMGenericModel> PHRMGenericModel { get; set; }
        public DbSet<PHRMGoodsReceiptItemsModel> PHRMGoodsReceiptItems { get; set; }
        public DbSet<PHRMGoodsReceiptModel> PHRMGoodsReceipt { get; set; }
        public DbSet<PHRMInvoiceTransactionItemsModel> PHRMInvoiceTransactionItems { get; set; }
        public DbSet<PHRMInvoiceTransactionModel> PHRMInvoiceTransaction { get; set; }
        public DbSet<PHRMItemMasterModel> PHRMItemMaster { get; set; }
        public DbSet<PHRMItemTypeModel> PHRMItemType { get; set; }
        public DbSet<PHRMPackingTypeModel> PHRMPackingType { get; set; }
        public DbSet<PHRMPatient> PHRMPatient { get; set; }
        public DbSet<PHRMPrescriptionItemModel> PHRMPrescriptionItems { get; set; }
        public DbSet<PHRMPrescriptionModel> PHRMPrescription { get; set; }
        public DbSet<PHRMRackModel> PHRMRack { get; set; }
        public DbSet<PHRMSupplierModel> PHRMSupplier { get; set; }
        public DbSet<PHRMTAXModel> PHRMTAX { get; set; }
        public DbSet<PHRMUnitOfMeasurementModel> PHRMUnitOfMeasurement { get; set; }
        public DbSet<RbacPermission> Permissions { get; set; }
        public DbSet<RbacUser> Users { get; set; }
        public DbSet<VisitModel> PHRMPatientVisit { get; set; }
        public DbSet<PHRMPrescriptionModel> PHRMPrescription { get; set; }
        public DbSet<PHRMPrescriptionItemModel> PHRMPrescriptionItems { get; set; }
        public DbSet<PHRMBillTransactionModel> PHRMBillTransaction { get; set; }
        public DbSet<PHRMBillTransactionItem> PHRMBillTransactionItems { get; set; }
        public DbSet<PHRMInvoiceTransactionModel> PHRMInvoiceTransaction { get; set; }
        public DbSet<PHRMInvoiceTransactionItemsModel> PHRMInvoiceTransactionItems { get; set; }
        public DbSet<PHRMReturnToSupplierModel> PHRMReturnToSupplier { get; set; }
        public DbSet<PHRMReturnToSupplierItemsModel> PHRMReturnToSupplierItem { get; set; }
        public DbSet<PHRMWriteOffModel> PHRMWriteOff { get; set; }
        public DbSet<PHRMStoreSalesCategoryModel> PHRMStoreSalesCategory { get; set; }
        public DbSet<PHRMWriteOffItemsModel> PHRMWriteOffItem { get; set; }
        public DbSet<PHRMInvoiceReturnItemsModel> PHRMInvoiceReturnItemsModel { get; set; }
        public DbSet<PHRMInvoiceReturnModel> PHRMInvoiceReturnModel { get; set; }
        public DbSet<EmployeePreferences> EmployeePreferences { get; set; }
        public DbSet<PHRMGenericModel> PHRMGenericModel { get; set; }
        public DbSet<PHRMNarcoticRecord> PHRMNarcoticRecord { get; set; }
        public DbSet<PHRMStoreModel> PHRMStore { get; set; } //sanjit 8Apr'19
        public DbSet<PHRMCounter> PHRMCounters { get; set; }
        public DbSet<PHRMGenericDosageNFreqMap> GenericDosageMaps { get; set; }//sud: 15Jul'18
        public DbSet<IRDLogModel> IRDLog { get; set; }
        public DbSet<PHRMDrugsRequistionModel> DrugRequistion { get; set; }
        public DbSet<PHRMDrugsRequistionItemsModel> DrugRequistionItem { get; set; }
        public DbSet<PHRMDepositModel> DepositModel { get; set; }
        public DbSet<PharmacyFiscalYear> PharmacyFiscalYears { get; set; }
        public DbSet<PHRMSettlementModel> PHRMSettlements { get; set; }
        public DbSet<WARDRequisitionModel> WardRequisition { get; set; }
        public DbSet<WARDRequisitionItemsModel> WardRequisitionItem { get; set; }
        public DbSet<WardModel> WardModel { get; set; }
        public DbSet<WARDStockModel> WardStock { get; set; }
        public DbSet<WARDDispatchModel> WardDisapatch { get; set; }
        public DbSet<WARDDispatchItemsModel> WardDispatchItems { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<WARDConsumptionModel> WardConsumption { get; set; }

        public DbSet<CountrySubDivisionModel> CountrySubDivision { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<PHRMStoreRequisitionModel> StoreRequisition { get; set; }
        public DbSet<PHRMStoreRequisitionItemsModel> StoreRequisitionItems { get; set; }
        public DbSet<PHRMDispatchItemsModel> StoreDispatchItems { get; set; }
        public DbSet<WARDTransactionModel> WardTransactionModel { get; set; }
        public DbSet<InventoryTermsModel> Terms { get; set; }
        public DbSet<PHRMCreditOrganizationsModel> CreditOrganizations { get; set; }
        public DbSet<PHRMMRPHistoryModel> MRPHistories { get; set; }
        public DbSet<InvoiceHeaderModel> InvoiceHeader { get; set; }
        public DbSet<CfgParameterModel> CFGParameters { get; set; }
        public DbSet<PHRMExpiryDateBatchNoHistoryModel> ExpiryDateBatchNoHistories { get; set; }
        public DbSet<PHRMStockMaster> StockMasters { get; set; }
        public DbSet<PHRMStoreStockModel> StoreStocks { get; set; }
        public DbSet<PHRMStockTransactionModel> StockTransactions { get; set; }
        public DbSet<InsuranceModel> PatientInsurances { get; set; }
        public DbSet<RbacPermission> Permissions { get; set; }
        public DbSet<PHRMSupplierLedgerModel> SupplierLedger { get; set; }
        public DbSet<PHRMSupplierLedgerTransactionModel> SupplierLedgerTransactions { get; set; }
        public DbSet<PHRMStockBarcode> StockBarcodes { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Entity to Table mappings
    modelBuilder.Entity<PHRMSettlementModel>().ToTable("PHRM_TXN_Settlement");
    modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
    modelBuilder.Entity<RbacUser>().ToTable("RBAC_User");
    modelBuilder.Entity<PHRMRackModel>().ToTable("PHRM_MST_Rack");
    modelBuilder.Entity<PHRMGenericModel>().ToTable("PHRM_MST_Generic");
    modelBuilder.Entity<PHRMSupplierModel>().ToTable("PHRM_MST_Supplier");
    modelBuilder.Entity<PHRMCompanyModel>().ToTable("PHRM_MST_Company");

            
            
            modelBuilder.Entity<PHRMCategoryModel>().ToTable("PHRM_MST_Category");
            modelBuilder.Entity<PHRMUnitOfMeasurementModel>().ToTable("PHRM_MST_UnitOfMeasurement");
            modelBuilder.Entity<PHRMItemTypeModel>().ToTable("PHRM_MST_ItemType");
            modelBuilder.Entity<PHRMPackingTypeModel>().ToTable("PHRM_MST_PackingType");
            modelBuilder.Entity<PHRMPurchaseOrderModel>().ToTable("PHRM_PurchaseOrder");
            modelBuilder.Entity<PHRMPurchaseOrderItemsModel>().ToTable("PHRM_PurchaseOrderItems");
            modelBuilder.Entity<PHRMItemMasterModel>().ToTable("PHRM_MST_Item");
            modelBuilder.Entity<PHRMTAXModel>().ToTable("PHRM_MST_TAX");
            modelBuilder.Entity<PHRMPatient>().ToTable("PAT_Patient");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
            modelBuilder.Entity<PHRMGoodsReceiptModel>().ToTable("PHRM_GoodsReceipt");
            modelBuilder.Entity<PHRMGoodsReceiptItemsModel>().ToTable("PHRM_GoodsReceiptItems");
            modelBuilder.Entity<PHRMPrescriptionModel>().ToTable("PHRM_Prescription");
            modelBuilder.Entity<PHRMPrescriptionItemModel>().ToTable("PHRM_PrescriptionItems");
            modelBuilder.Entity<PHRMReturnToSupplierModel>().ToTable("PHRM_ReturnToSupplier");
            modelBuilder.Entity<PHRMReturnToSupplierItemsModel>().ToTable("PHRM_ReturnToSupplierItems");
            modelBuilder.Entity<PHRMBillTransactionModel>().ToTable("PHRM_BIL_Transaction");
            modelBuilder.Entity<PHRMBillTransactionItem>().ToTable("PHRM_BIL_TransactionItem");
            modelBuilder.Entity<PHRMInvoiceTransactionModel>().ToTable("PHRM_TXN_Invoice");
            modelBuilder.Entity<PHRMInvoiceTransactionItemsModel>().ToTable("PHRM_TXN_InvoiceItems");
            modelBuilder.Entity<PHRMWriteOffModel>().ToTable("PHRM_WriteOff");
            modelBuilder.Entity<PHRMWriteOffItemsModel>().ToTable("PHRM_WriteOffItems");
            modelBuilder.Entity<PHRMInvoiceReturnItemsModel>().ToTable("PHRM_TXN_InvoiceReturnItems");
            modelBuilder.Entity<PHRMInvoiceReturnModel>().ToTable("PHRM_TXN_InvoiceReturn");
            modelBuilder.Entity<EmployeePreferences>().ToTable("EMP_EmployeePreferences");
            modelBuilder.Entity<PHRMNarcoticRecord>().ToTable("PHRM_NarcoticSaleRecord");
            modelBuilder.Entity<PHRMCounter>().ToTable("PHRM_MST_Counter");
            modelBuilder.Entity<PHRMGenericDosageNFreqMap>().ToTable("PHRM_MAP_GenericDosaseNFreq");//sud: 15Jul'18
            modelBuilder.Entity<IRDLogModel>().ToTable("IRD_Log");
            modelBuilder.Entity<PHRMDrugsRequistionModel>().ToTable("PHRM_Requisition");
            modelBuilder.Entity<PHRMDrugsRequistionItemsModel>().ToTable("PHRM_RequisitionItems");
            modelBuilder.Entity<PHRMDepositModel>().ToTable("PHRM_Deposit");
            modelBuilder.Entity<PharmacyFiscalYear>().ToTable("PHRM_CFG_FiscalYears");
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<WARDRequisitionModel>().ToTable("WARD_Requisition");
            modelBuilder.Entity<WARDRequisitionItemsModel>().ToTable("WARD_RequisitionItems");
            modelBuilder.Entity<WardModel>().ToTable("ADT_MST_Ward");
            modelBuilder.Entity<WARDStockModel>().ToTable("WARD_Stock");
            modelBuilder.Entity<WARDDispatchModel>().ToTable("WARD_Dispatch");
            modelBuilder.Entity<WARDDispatchItemsModel>().ToTable("WARD_DispatchItems");
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<WARDConsumptionModel>().ToTable("WARD_Consumption");
            modelBuilder.Entity<PHRMStoreModel>().ToTable("PHRM_MST_Store");
            modelBuilder.Entity<CountrySubDivisionModel>().ToTable("MST_CountrySubDivision");
            modelBuilder.Entity<PHRMStoreSalesCategoryModel>().ToTable("PHRM_MST_SalesCategory");
            modelBuilder.Entity<PHRMStoreRequisitionModel>().ToTable("PHRM_StoreRequisition");
            modelBuilder.Entity<PHRMStoreRequisitionItemsModel>().ToTable("PHRM_StoreRequisitionItems");
            modelBuilder.Entity<PHRMDispatchItemsModel>().ToTable("PHRM_StoreDispatchItems");
            modelBuilder.Entity<WARDTransactionModel>().ToTable("WARD_Transaction");
            modelBuilder.Entity<InventoryTermsModel>().ToTable("INV_MST_Terms");
            modelBuilder.Entity<PHRMCreditOrganizationsModel>().ToTable("PHRM_MST_Credit_Organization");
            modelBuilder.Entity<PHRMMRPHistoryModel>().ToTable("PHRM_History_StockMRP");
            modelBuilder.Entity<InvoiceHeaderModel>().ToTable("MST_InvoiceHeaders");
            modelBuilder.Entity<CfgParameterModel>().ToTable("CORE_CFG_Parameters");
            modelBuilder.Entity<PHRMExpiryDateBatchNoHistoryModel>().ToTable("PHRM_History_StockBatchExpiry");
            modelBuilder.Entity<PHRMStockMaster>().ToTable("PHRM_MST_Stock");
            modelBuilder.Entity<PHRMStockTransactionModel>().ToTable("PHRM_TXN_StockTransaction");
            modelBuilder.Entity<InsuranceModel>().ToTable("PAT_PatientInsuranceInfo");
            modelBuilder.Entity<RbacPermission>().ToTable("RBAC_Permission");
            modelBuilder.Entity<PHRMSupplierLedgerModel>().ToTable("PHRM_TXN_SupplierLedger");
            modelBuilder.Entity<PHRMSupplierLedgerTransactionModel>().ToTable("PHRM_TXN_SupplierLedgerTransaction");


 // Relationships
    modelBuilder.Entity<PHRMStoreStockModel>()
        .HasOne(a => a.StockMaster)
        .WithMany(a => a.StoreStocks)
        .HasForeignKey(a => a.StockId);

    modelBuilder.Entity<PHRMStockMaster>()
        .HasOne(a => a.StockBarcode)
        .WithOne()
        .HasForeignKey<PHRMStockBarcode>(b => b.StockMasterId); // Assuming StockMasterId is the FK in StockBarcode

    // For decimal precision
    foreach (var property in modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
    {
        property.SetColumnType("decimal(16, 4)");
    }
}

#region PHRM Stock Items Report        
public DataTable GetMainStoreStock(bool ShowStockFromAllStores)
{
    // EF Core doesn't support direct execution of stored procedures that return entities. 
    // You'll need to use FromSqlRaw or similar methods.
    // Here's a basic example, but you might need to adjust based on your actual needs:

    using (var command = Database.GetDbConnection().CreateCommand())
    {
        command.CommandText = "SP_PHRM_GetMainStoreStockDetails";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@ShowStockFromAllStores", ShowStockFromAllStores));

        Database.OpenConnection();

        using (var result = command.ExecuteReader())
        {
            var dataTable = new DataTable();
            dataTable.Load(result);
            return dataTable;
        }
    }
}
#endregion
