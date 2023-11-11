using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.ServerModel.HelpdeskModels;
using DanpheEMR.ServerModel.ReportingModels;
using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;

namespace DanpheEMR.DalLayer
{
    public class HelpdeskDbContext : DbContext
    {
        public DbSet<EmployeeInfoModel> EmployeeInfo { get; set; }
        public DbSet<BedInformationModel> BedInfo { get; set; }
        public DbSet<WardInformationModel> WardInfo { get; set; }

        public HelpdeskDbContext(DbContextOptions<HelpdeskDbContext> options) : base(options)
        {
        }

        public List<EmployeeInfoModel> GetEmployeeInfo()
        {
            return EmployeeInfo.FromSqlRaw("SP_Report_HDSK_EmployeeInfo").ToList();
        }

        public DynamicReport GetBedInformation()
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "sp_BedInformation";
                command.CommandType = CommandType.StoredProcedure;
                Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    var bedInfoList = new List<BedInformationModel>();
                    var wardInfoList = new List<WardInformationModel>();
                    while (result.Read())
                    {
                        var bedInfo = new BedInformationModel
                        {
                            // Map your properties here
                        };
                        bedInfoList.Add(bedInfo);
                    }

                    result.NextResult();

                    while (result.Read())
                    {
                        var wardInfo = new WardInformationModel
                        {
                            // Map your properties here
                        };
                        wardInfoList.Add(wardInfo);
                    }

                    DynamicReport dReport = new DynamicReport
                    {
                        // Populate your DynamicReport object here
                    };

                    return dReport;
                }
            }
        }

        public List<WardInformationModel> GetWardInformation()
        {
            return WardInfo.FromSqlRaw("SP_ADT_GetBedOccupanciesOfAllWards").ToList();
        }

        public DataTable GetBedOccupancyOfWards()
        {
            // Assuming you have a method to get DataTable from stored procedure
            DataTable bedfeature = GetDataTableFromStoredProc("SP_ADT_GetBedOccupanciesOfAllWards");
            return bedfeature;
        }

        private DataTable GetDataTableFromStoredProc(string storedProcName)
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = storedProcName;
                command.CommandType = CommandType.StoredProcedure;
                Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define your entity configurations here
        }
    }
}

