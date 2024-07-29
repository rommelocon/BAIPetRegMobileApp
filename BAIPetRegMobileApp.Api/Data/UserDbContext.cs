using BAIPetRegMobileApp.Api.Models.PetRegistration;
using BAIPetRegMobileApp.Api.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        // Location DbSet
        public DbSet<Regions> TblRegions { get; set; }
        public DbSet<Municipalities> TblMunicipalities { get; set; }
        public DbSet<Provinces> TblProvinces { get; set; }
        public DbSet<Barangays> TblBarangays { get; set; }

        public DbSet<Species> TblSpecies { get; set; }
        public DbSet<SexType> TblSexType { get; set; }
        public DbSet<RegistrationOption> TblRegistrationOptions { get; set; }
        public DbSet<CivilStatuses> TblCivilStatus { get; set; }
        public DbSet<AgencyName> TblAgencyName { get; set; }
        public DbSet<AccessLevel> TblAccessLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePrimaryKeys(modelBuilder);
            ConfigureRelationships(modelBuilder);
            ConfigureApplicationUser(modelBuilder);
        }

        private void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CivilStatuses>().HasKey(cs => cs.CivilCode);
            modelBuilder.Entity<Regions>().HasKey(r => r.Rcode);
            modelBuilder.Entity<Provinces>().HasKey(p => p.ProvCode);
            modelBuilder.Entity<Municipalities>().HasKey(m => m.MunCode);
            modelBuilder.Entity<Barangays>().HasKey(b => b.Bcode);
            modelBuilder.Entity<AccessLevel>().HasKey(al => al.AccessLevelID);
            modelBuilder.Entity<AgencyName>().HasKey(an => an.AgencyID);
            modelBuilder.Entity<SexType>().HasKey(st => st.SexID);
            modelBuilder.Entity<RegistrationOption>().HasKey(ro => ro.RegOptID);
            modelBuilder.Entity<Species>().HasKey(s => s.SpeciesID);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barangays>()
                .HasOne(b => b.Municipalities)
                .WithMany(m => m.Barangays)
                .HasForeignKey(b => b.MunCode);

            modelBuilder.Entity<Provinces>()
                .HasOne(p => p.Regions)
                .WithMany(r => r.Provinces)
                .HasForeignKey(p => p.Rcode);

            modelBuilder.Entity<Municipalities>()
                .HasOne(m => m.Provinces)
                .WithMany(p => p.Municipalities)
                .HasForeignKey(m => m.ProvCode);
        }

        private void ConfigureApplicationUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail).HasDatabaseName("EmailIndex");
                entity.HasIndex(e => e.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();

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
        }
    }
}