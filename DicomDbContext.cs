using Microsoft.EntityFrameworkCore;
using DanpheEMR.ServerModel;

namespace DanpheEMR.DalLayer
{
    public class DicomDbContext : DbContext
    {
        public DicomDbContext(DbContextOptions<DicomDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientStudyModel>().ToTable("DCM_PatientStudy");
            modelBuilder.Entity<DicomFileInfoModel>().ToTable("DCM_DicomFiles");
            modelBuilder.Entity<SeriesInfoModel>().ToTable("DCM_Series");
        }

        public DbSet<PatientStudyModel> PatientStudies { get; set; }
        public DbSet<DicomFileInfoModel> DicomFiles { get; set; }
        public DbSet<SeriesInfoModel> Series { get; set; }
    }
}

