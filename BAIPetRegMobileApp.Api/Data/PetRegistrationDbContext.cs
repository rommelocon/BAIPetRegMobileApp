using BAIPetRegMobileApp.Api.Data.PetRegistration;
using BAIPetRegMobileApp.Api.Data.User;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    public class PetRegistrationDbContext : DbContext
    {
        public PetRegistrationDbContext(DbContextOptions<PetRegistrationDbContext> options) : base(options) { }

        // Pet Registration DbSet
        public DbSet<PetRegistration.PetRegistration> TblPetRegistration { get; set; }
        public DbSet<OwnerShipType> TblOwnerShipType { get; set; }
        public DbSet<SexType> TblSexType { get; set; }
        public DbSet<AnimalFemaleClassification> TblAnimalFemalClassification { get; set; }
        public DbSet<AnimalColor> TblAnimalColor { get; set; }
        public DbSet<SpeciesGroup> TblSpeciesGroup { get; set; }
        public DbSet<SpeciesBreed> TblSpeciesBreed { get; set; }

        // Location DbSet
        public DbSet<Regions> TblRegions { get; set; }
        public DbSet<Provinces> TblProvinces { get; set; }
        public DbSet<Municipalities> TblMunicipalities { get; set; }
        public DbSet<Barangays> TblBarangays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePrimaryKeys(modelBuilder);
            ConfigureRelationships(modelBuilder);
            ConfigurePetRegistration(modelBuilder);
        }

        private void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetRegistration.PetRegistration>().HasKey(pr => pr.PetRegistrationID);
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
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
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

        private void ConfigurePetRegistration(ModelBuilder modelBuilder)
        {

        }
    }
}
