using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.Core.Parameters;

namespace DanpheEMR.DalLayer
{
    public class PayrollDbContext : DbContext
    {
        public DbSet<AttendanceDailyTimeRecord> AttendanceDailyTimeRecords { get; set; }
        public DbSet<DailyMuster> DailyMusters { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<WeekendHolidays> WeekendHolidays { get; set; }
        public DbSet<LeaveCategory> LeaveCategories { get; set; }
        public DbSet<ParameterModel> ParameterModels { get; set; }
        public DbSet<LeaveRuleModel> LeaveRuleModels { get; set; }
        public DbSet<HolidayModel> HolidayList { get; set; }
        public DbSet<EmployeeLeaveModel> EmployeeLeaveModels { get; set; }

        public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceDailyTimeRecord>().ToTable("PROLL_AttendanceDailyTimeRecord");
            modelBuilder.Entity<DailyMuster>().ToTable("PROLL_DailyMuster");
            modelBuilder.Entity<EmployeeModel>().ToTable("EMP_Employee");
            modelBuilder.Entity<WeekendHolidays>().ToTable("PROLL_MST_WeekendHolidays");
            modelBuilder.Entity<LeaveCategory>().ToTable("PROLL_MST_LeaveCategory");
            modelBuilder.Entity<ParameterModel>().ToTable("CORE_CFG_Parameters");
            modelBuilder.Entity<LeaveRuleModel>().ToTable("PROLL_MST_LeaveRules");
            modelBuilder.Entity<HolidayModel>().ToTable("PROLL_MST_Holidays");
            modelBuilder.Entity<EmployeeLeaveModel>().ToTable("PROLL_EmpLeave");
        }
    }
}

