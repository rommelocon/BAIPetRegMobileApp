using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        // Location DbSet
        public DbSet<TblRegions> TblRegions { get; set; }
        public DbSet<TblMunicipalities> TblMunicipalities { get; set; }
        public DbSet<TblProvinces> TblProvinces { get; set; }
        public DbSet<TblBarangays> TblBarangays { get; set; }

        public DbSet<TblSpecies> TblSpecies { get; set; }
        public DbSet<TblSexType> TblSexType { get; set; }
        public DbSet<TblRegistrationOption> TblRegistrationOptions { get; set; }
        public DbSet<TblCivilStatus> TblCivilStatus { get; set; }
        public DbSet<TblAgencyName> TblAgencyName { get; set; }
        public DbSet<TblAccessLevel> TblAccessLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary keys
            modelBuilder.Entity<TblCivilStatus>(entity =>
            {
                entity.HasKey(cs => cs.CivilCode);
            });
            modelBuilder.Entity<TblRegions>(entity =>
            {
                entity.HasKey(r => r.Rcode);
            });
            modelBuilder.Entity<TblProvinces>(entity =>
            {
                entity.HasKey(p => p.ProvCode);
            });
            modelBuilder.Entity<TblMunicipalities>(entity =>
            {
                entity.HasKey(m => m.MunCode);
            });
            modelBuilder.Entity<TblBarangays>(entity =>
            {
                entity.HasKey(b => b.Bcode);
            });
            modelBuilder.Entity<TblAccessLevel>(entity =>
            {
                entity.HasKey(al => al.AccessLevelID);
            });
            modelBuilder.Entity<TblAgencyName>(entity =>
            {
                entity.HasKey(an => an.AgencyID);
            });
            modelBuilder.Entity<TblSexType>(entity =>
            {
                entity.HasKey(st => st.SexID);
            });
            modelBuilder.Entity<TblRegistrationOption>(entity =>
            {
                entity.HasKey(ro => ro.RegOptID);
            });
            modelBuilder.Entity<TblSpecies>(entity =>
            {
                entity.HasKey(s => s.SpeciesID);
            });

            // Configure relationships
            modelBuilder.Entity<TblBarangays>()
                .HasOne(m => m.Municipalities)
                .WithMany(b => b.Barangays)
                .HasForeignKey(m => m.MunCode);

            modelBuilder.Entity<TblProvinces>()
                .HasOne(p => p.Regions)
                .WithMany(r => r.Provinces)
                .HasForeignKey(p => p.Rcode);

            modelBuilder.Entity<TblMunicipalities>()
                .HasOne(m => m.Provinces)
                .WithMany(p => p.Municipalities)
                .HasForeignKey(m => m.ProvCode);

            // Configure ApplicationUser relationships
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail).HasDatabaseName("EmailIndex");
                entity.HasIndex(e => e.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();

                // Configure additional properties and relationships
                entity.HasOne(e => e.RegistrationOption)
                    .WithMany()
                    .HasForeignKey(e => e.RegOptID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.SexType)
                    .WithMany()
                    .HasForeignKey(e => e.SexID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.AgencyName)
                    .WithMany()
                    .HasForeignKey(e => e.AgencyID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.AccessLevel)
                    .WithMany()
                    .HasForeignKey(e => e.AccessLevelID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.CivilStatus)
                    .WithMany()
                    .HasForeignKey(e => e.CivilStatusCode)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Additional configurations for other entities
        }
    }
}