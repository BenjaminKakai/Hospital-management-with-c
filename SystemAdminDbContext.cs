using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;

namespace DanpheEMR.DalLayer
{
    public class SystemAdminDbContext : DbContext
    {
        public SystemAdminDbContext(DbContextOptions<SystemAdminDbContext> options) : base(options)
        {
        }

        public DbSet<DatabaseLogModel> DatabaseLog { get; set; }
        public DbSet<AdminParametersModel> AdminParameters { get; set; }
        public DbSet<LoginInformationModel> LoginInformation { get; set; }
        public DbSet<CookieAuthInfoModel> CookieInformation { get; set; }
        public DbSet<AuditTableDisplayName> AuditTableDisplayNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseLogModel>().ToTable("SysAdmin_DBLog");
            modelBuilder.Entity<AdminParametersModel>().ToTable("SysAdmin_Parameters");
            modelBuilder.Entity<LoginInformationModel>().ToTable("DanpheLogInInformation");
            modelBuilder.Entity<CookieAuthInfoModel>().ToTable("Danphe_CookieAuthInfo");
            modelBuilder.Entity<AuditTableDisplayName>().ToTable("tbl_AuditTableDisplayName");
        }
    }
}

