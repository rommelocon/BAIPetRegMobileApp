using BAIPetRegMobileApp.Api.Models.PetRegistration;
using BAIPetRegMobileApp.Api.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    public class PetRegistrationDbContext : DbContext
    {
        public PetRegistrationDbContext(DbContextOptions<PetRegistrationDbContext> options) : base(options) { }

        public DbSet<PetRegistrationModel> TblPetRegistration { get; set; }
        public DbSet<OwnerShipType> TblOwnerShipType { get; set; }
        public DbSet<SexType> TblSexType { get; set; }
        public DbSet<AnimalFemaleClassification> TblAnimalFemalClassification { get; set; }
        public DbSet<AnimalColor> TblAnimalColor { get; set; }
        public DbSet<SpeciesGroup> TblSpeciesGroup { get; set; }
        public DbSet<Regions> TblRegions { get; set; }
        public DbSet<Provinces> TblProvinces { get; set; }
        public DbSet<Municipalities> TblMunicipalities { get; set; }
        public DbSet<Barangays> TblBarangays { get; set; }
        public DbSet<SpeciesBreed> TblSpeciesBreed { get; set; }
        public DbSet<RegistrationOption> TblRegistrationOptions { get; set; }
        public DbSet<CivilStatuses> TblCivilStatus { get; set; }
        public DbSet<AgencyName> TblAgencyName { get; set; }
        public DbSet<AccessLevel> TblAccessLevel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePrimaryKeys(modelBuilder);
            ConfigureRelationships(modelBuilder);
        }

        private void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetRegistrationDto>().HasKey(pr => pr.PetRegistrationID);
            modelBuilder.Entity<OwnerShipType>().HasKey(ot => ot.OwnerShipTypeID);
            modelBuilder.Entity<SexType>().HasKey(st => st.SexID);
            modelBuilder.Entity<AnimalFemaleClassification>().HasKey(afc => afc.AnimalFemaleClassID);
            modelBuilder.Entity<AnimalColor>().HasKey(ac => ac.AnimalColorID);
            modelBuilder.Entity<SpeciesGroup>().HasKey(sg => sg.SpeciesCode);
            modelBuilder.Entity<SpeciesBreed>().HasKey(sb => sb.BreedID);
            modelBuilder.Entity<Regions>().HasKey(r => r.Rcode);
            modelBuilder.Entity<Provinces>().HasKey(p => p.ProvCode);
            modelBuilder.Entity<Municipalities>().HasKey(m => m.MunCode);
            modelBuilder.Entity<Barangays>().HasKey(b => b.Bcode);
            modelBuilder.Entity<AccessLevel>().HasKey(al => al.AccessLevelID);
            modelBuilder.Entity<AgencyName>().HasKey(an => an.AgencyID);
            modelBuilder.Entity<RegistrationOption>().HasKey(ro => ro.RegOptID);
            modelBuilder.Entity<CivilStatuses>().HasKey(cs => cs.CivilCode);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetRegistrationModel>()
                .HasOne(pr => pr.Client)
                .WithMany()
                .HasForeignKey(p => p.ClientID);

            modelBuilder.Entity<SpeciesBreed>()
                .HasOne(sb => sb.SpeciesGroup)
                .WithMany(sg => sg.Breeds)
                .HasForeignKey(sb => sb.SpeciesCode);

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
    }
}
