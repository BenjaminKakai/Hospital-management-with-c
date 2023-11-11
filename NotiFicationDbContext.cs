using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;
using DanpheEMR.ServerModel.NotificationModels;

namespace DanpheEMR.DalLayer
{
    public class NotiFicationDbContext : DbContext
    {
        public DbSet<NotificationViewModel> Notifications { get; set; }
        public DbSet<VisitModel> PatientVisits { get; set; }

        public NotiFicationDbContext(DbContextOptions<NotiFicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotificationViewModel>().ToTable("CORE_Notification");
            modelBuilder.Entity<VisitModel>().ToTable("PAT_PatientVisits");
        }
    }
}

