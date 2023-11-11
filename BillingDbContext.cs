using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanpheEMR.ServerModel;
using Microsoft.EntityFrameworkCore;
using Audit.EntityFramework;

namespace DanpheEMR.DalLayer
{
    public class BillingDbContext : AuditDbContext
    {
        public DbSet<BillingTransactionModel> BillingTransactions { get; set; }
        public DbSet<ServiceDepartmentModel> ServiceDepartment { get; set; }
        public DbSet<BillItemPrice> BillItemPrice { get; set; }
        public DbSet<BillItemRequisition> BillItemRequisitions { get; set; }
        public DbSet<BillingTransactionItemModel> BillingTransactionItems { get; set; }
        public DbSet<BillingDeposit> BillingDeposits { get; set; }
        public DbSet<BillingCounter> BillingCounter { get; set; }
        public DbSet<BillItemPriceHistory> BillItemPriceHistory { get; set; }
        public DbSet<BillingPackageModel> BillingPackages { get; set; }
        public DbSet<LabRequisitionModel> LabRequisitions { get; set; }
        public DbSet<ImagingRequisitionModel> RadiologyImagingRequisitions { get; set; }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<VisitModel> Visit { get; set; }
        public DbSet<PatientMembershipModel> PatientMembership { get; set; }
        public DbSet<MembershipTypeModel> MembershipType { get; set; }
        public DbSet<CountrySubDivisionModel> CountrySubdivisions { get; set; }
        public DbSet<BillingFiscalYear> BillingFiscalYears { get; set; }
        public DbSet<BillInvoiceReturnModel> BillInvoiceReturns { get; set; }
        public DbSet<BillSettlementModel> BillSettlements { get; set; }
        public DbSet<SyncBillingAccountingModel> SyncBillingAccounting { get; set; }
        public DbSet<AdmissionModel> Admissions { get; set; }
        public DbSet<PatientBedInfo> PatientBedInfos { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<IRDLogModel> IRDLog { get; set; }
        public DbSet<RbacUser> User { get; set; }
        public DbSet<History_BillingTransactionItem> History_BillingTxnItems { get; set; }
        public DbSet<WardModel> Wards { get; set; }
        public DbSet<BedModel> Beds { get; set; }
        public DbSet<BedFeature> BedFeatures { get; set; }
        public DbSet<BedFeaturesMap> BedFeaturesMaps { get; set; }
        public DbSet<InsuranceModel> Insurances { get; set; }
        public DbSet<InsuranceProviderModel> InsuranceProviders { get; set; }
        public DbSet<PatientInsurancePackageTransactionModel> PatientInsurancePackageTransactions { get; set; }
        public DbSet<CreditOrganizationModel> CreditOrganization { get; set; }
        public DbSet<BanksModel> Banks { get; set; }
        public DbSet<BillingHandoverTransactionModel> HandoverTransaction { get; set; }
        public DbSet<BillingHandoverModel> Handover { get; set; }
        public DbSet<BillingDenominationModel> Denomination { get; set; }
        public DbSet<LabTestModel> LabTests { get; set; }
        public DbSet<AdminParametersModel> AdminParameters { get; set; }
        public DbSet<EmpCashTransactionModel> EmpCashTransactions { get; set; }
        public DbSet<EmpDueAmountModel> EmpDueAmounts { get; set; }
        public DbSet<BillInvoiceReturnItemsModel> BillInvoiceReturnItems { get; set; }
        public DbSet<PrinterSettingsModel> PrinterSettings { get; set; }
        public DbSet<DynamicReportNameModel> DynamicReportNameModels { get; set; }
        public DbSet<ReportingItemsModel> ReportingItemsModels { get; set; }
        public DbSet<ReportingItemBillingItemMapping> ReportingItemsAndBillingItemMappingModels { get; set; }
        public DbSet<RadiologyImagingTypeModel> RadiologyImagingTypes { get; set; }
        public DbSet<RadiologyImagingItemModel> RadiologyImagingItems { get; set; }
        public DbSet<LabVendorsModel> LabVendors { get; set; }
        public object ReportingItemsModel { get; set; }

        public BillingDbContext(string conn) : base(conn)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            this.AuditDisabled = true;
        }
        public DbSet<IntegrationModel> IntegrationName { get; set; }

        
        
        

       protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<BillingTransactionModel>().ToTable("BIL_TXN_BillingTransaction");
    modelBuilder.Entity<PatientModel>().ToTable("PAT_Patient");
    modelBuilder.Entity<PatientMembershipModel>().ToTable("PAT_PatientMembership");
    modelBuilder.Entity<MembershipTypeModel>().ToTable("PAT_CFG_MembershipType");
    modelBuilder.Entity<ServiceDepartmentModel>().ToTable("BIL_MST_ServiceDepartment");
    modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
    modelBuilder.Entity<LabRequisitionModel>().ToTable("LAB_TestRequisition");
    modelBuilder.Entity<ImagingRequisitionModel>().ToTable("RAD_PatientImagingRequisition");
    modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
    modelBuilder.Entity<ReportingItemsModel>().ToTable("MST_RPT_DynamicReportingItems");
    modelBuilder.Entity<DynamicReportNameModel>().ToTable("MST_RPT_DynamicReportName");
    modelBuilder.Entity<ReportingItemBillingItemMapping>().ToTable("BIL_MAP_ReportingItem_BillingItems");
    modelBuilder.Entity<BillingTransactionItemModel>().ToTable("BIL_TXN_BillingTransactionItems");
    modelBuilder.Entity<BillingTransactionItemModel>()
          .HasOne<BillingTransactionModel>(s => s.BillingTransaction)
          .WithMany(s => s.BillingTransactionItems)
          .HasForeignKey(s => s.BillingTransactionId);
    modelBuilder.Entity<BillItemPrice>().ToTable("BIL_CFG_BillItemPrice");
    modelBuilder.Entity<RadiologyImagingTypeModel>().ToTable("RAD_MST_ImagingType");
    modelBuilder.Entity<RadiologyImagingItemModel>().ToTable("RAD_MST_ImagingItem");
    modelBuilder.Entity<BillItemRequisition>().ToTable("BIL_BillItemRequisition");
    modelBuilder.Entity<BillingDeposit>().ToTable("BIL_TXN_Deposit");
    modelBuilder.Entity<BillingCounter>().ToTable("BIL_CFG_Counter");
    modelBuilder.Entity<BillingPackageModel>().ToTable("BIL_CFG_Packages");
    modelBuilder.Entity<CountrySubDivisionModel>().ToTable("MST_CountrySubDivision");
    modelBuilder.Entity<BillingFiscalYear>().ToTable("BIL_CFG_FiscalYears");
    modelBuilder.Entity<BillInvoiceReturnModel>().ToTable("BIL_TXN_InvoiceReturn");
    modelBuilder.Entity<BillSettlementModel>().ToTable("BIL_TXN_Settlements");
    modelBuilder.Entity<SyncBillingAccountingModel>().ToTable("BIL_SYNC_BillingAccounting");
    modelBuilder.Entity<AdmissionModel>().ToTable("ADT_PatientAdmission");
    modelBuilder.Entity<PatientBedInfo>().ToTable("ADT_TXN_PatientBedInfo");
    modelBuilder.Entity<DepartmentModel>().ToTable("MST_Department");
    modelBuilder.Entity<IRDLogModel>().ToTable("IRD_Log");
    modelBuilder.Entity<BillItemPriceHistory>().ToTable("BIL_CFG_BillItemPrice_History");
    modelBuilder.Entity<BedFeature>().ToTable("ADT_MST_BedFeature");
    modelBuilder.Entity<BedFeaturesMap>().ToTable("ADT_MAP_BedFeaturesMap");
    modelBuilder.Entity<WardModel>().ToTable("ADT_MST_Ward");
    modelBuilder.Entity<BedModel>().ToTable("ADT_Bed");
    modelBuilder.Entity<InsuranceModel>().ToTable("PAT_PatientInsuranceInfo");
    modelBuilder.Entity<InsuranceProviderModel>().ToTable("INS_CFG_InsuranceProviders");
    modelBuilder.Entity<PatientInsurancePackageTransactionModel>().ToTable("INS_TXN_PatientInsurancePackages");
    modelBuilder.Entity<CreditOrganizationModel>().ToTable("BIL_MST_Credit_Organization");
    modelBuilder.Entity<BanksModel>().ToTable("MST_Bank");
    modelBuilder.Entity<BillingHandoverTransactionModel>().ToTable("BIL_TXN_CashHandover");
    modelBuilder.Entity<BillingHandoverModel>().ToTable("BIL_MST_Handover");
    modelBuilder.Entity<BillingDenominationModel>().ToTable("BIL_TXN_Denomination");
    modelBuilder.Entity<LabTestModel>().ToTable("LAB_LabTests");
    modelBuilder.Entity<AdminParametersModel>().ToTable("CORE_CFG_Parameters");
    modelBuilder.Entity<RbacUser>().ToTable("RBAC_User");
    modelBuilder.Entity<EmpCashTransactionModel>().ToTable("TXN_EmpCashTransaction");
    modelBuilder.Entity<EmpDueAmountModel>().ToTable("TXN_EmpDueAmount");
    modelBuilder.Entity<BillInvoiceReturnItemsModel>().ToTable("BIL_TXN_InvoiceReturnItems");
    modelBuilder.Entity<PrinterSettingsModel>().ToTable("CFG_PrinterSettings");
    modelBuilder.Entity<LabVendorsModel>().ToTable("Lab_MST_LabVendors");
    modelBuilder.Entity<IntegrationModel>().ToTable("ServiceDepartment_MST_IntegrationName");
}

public DataTable GetItemsForBillingReceipt(int patientId, int? billingTxnId, string billStatus)
{
    List<SqlParameter> paramList = new List<SqlParameter>() {  
        new SqlParameter("@PatientId", patientId),
        new SqlParameter("@BillTxnId", billingTxnId.HasValue ? billingTxnId.Value : (int?)null),
        new SqlParameter("@BillStatus",billStatus) 
    };
    DataTable discountReportData = DALFunctions.GetDataTableFromStoredProc("SP_BIL_GetItems_ForIPBillingReceipt", paramList, this);
    return discountReportData;
}
    }

}
