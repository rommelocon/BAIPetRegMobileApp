using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
        {
        }

        public DbSet<TblProvinces> TblProvinces { get; set; }
        public DbSet<TblSpecies> TblSpecies { get; set; }
        public DbSet<TblSexType> TblSexTypes { get; set; }
        public DbSet<TblRegistrationOption> TblRegistrationOptions { get; set; }
        public DbSet<TblRegions> TblRegions { get; set; }
        public DbSet<TblMunicipalities> TblMunicipalities { get; set; }
        public DbSet<TblCivilStatus> TblCivilStatuses { get; set; }
        public DbSet<TblBarangays> TblBarangays { get; set; }
        public DbSet<TblAgencyName> TblAgencyName { get; set; }
        public DbSet<TblAccessLevel> TblAccessLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            });

            // Additional configurations for other entities
            // Configure primary keys
            modelBuilder.Entity<TblProvinces>()
                .HasKey(p => p.ProvCode);

            modelBuilder.Entity<TblMunicipalities>()
                .HasKey(m => m.MunCode);

            modelBuilder.Entity<TblBarangays>()
            .HasKey(b => b.Bcode);


            // Configure relationships
            modelBuilder.Entity<TblBarangays>()
                .HasOne(b => b.TblMunicipalities)
                .WithMany(m => m.TblBarangays)
                .HasForeignKey(b => b.MunCode);

            modelBuilder.Entity<TblProvinces>()
                .HasOne(p => p.TblRegions)
                .WithMany(r => r.TblProvinces)
                .HasForeignKey(p => p.Rcode);

            modelBuilder.Entity<TblMunicipalities>()
                .HasOne(m => m.TblProvinces)
                .WithMany(p => p.TblMunicipalities)
                .HasForeignKey(m => m.ProvCode);

            //Configure TblRegions
            modelBuilder.Entity<TblRegions>(entity =>
            {
                entity.HasKey(e => e.Rcode)
                      .HasName("TblRegions");

                entity.Property(e => e.Rcode)
                      .HasColumnName("Rcode")
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.RegionName)
                      .HasColumnName("Region")
                      .HasMaxLength(100);

                entity.Property(e => e.PSGC)
                      .HasColumnName("PSGC")
                      .HasMaxLength(50);

                entity.Property(e => e.Population2020)
                      .HasColumnName("Pop_2020");

                entity.HasMany(e => e.TblProvinces)
                      .WithOne(p => p.TblRegions)
                      .HasForeignKey(p => p.Rcode);
            });

            // Configure TblSpecies
            modelBuilder.Entity<TblSpecies>(entity =>
            {
                entity.HasKey(e => e.SpeciesID);

                entity.Property(e => e.SpeciesID)
                      .ValueGeneratedNever(); // Assumes SpeciesID is manually set

                entity.Property(e => e.SpeciesDescription)
                      .HasMaxLength(50);
            });
            // Configure TblSexType
            modelBuilder.Entity<TblSexType>(entity =>
            {
                entity.HasKey(e => e.SexID);

                entity.Property(e => e.SexID)
                      .ValueGeneratedNever(); // Assumes SexID is manually set

                entity.Property(e => e.SexDescription)
                      .HasMaxLength(50);
            });
            // Configure TblRegistrationOption
            modelBuilder.Entity<TblRegistrationOption>(entity =>
            {
                entity.HasKey(e => e.RegOptID);

                entity.Property(e => e.RegOptID)
                      .ValueGeneratedNever(); // Assumes RegOptID is manually set

                entity.Property(e => e.RegOptDescription)
                      .HasMaxLength(50);
            });
            // Configure entity for TblAccessLevel
            modelBuilder.Entity<TblAccessLevel>(entity =>
            {
                entity.HasKey(e => e.AccessLevelID);

                entity.Property(e => e.AccessLevelDescription)
                    .HasMaxLength(50)
                    .IsRequired(false);
            });

            // Configure entity for TblAgencyName
            modelBuilder.Entity<TblAgencyName>(entity =>
            {
                entity.HasKey(e => e.AgencyID);

                entity.Property(e => e.AgencyDescription)
                    .HasMaxLength(50)
                    .IsRequired(false);
            });

            // Configure TblCivilStatus
            modelBuilder.Entity<TblCivilStatus>(entity =>
            {
                entity.HasKey(e => e.CivilCode);

                entity.Property(e => e.CivilCode)
                      .ValueGeneratedNever(); // Key property

                entity.Property(e => e.CivilStatus)
                      .HasMaxLength(50);
            });
        }
    }
}