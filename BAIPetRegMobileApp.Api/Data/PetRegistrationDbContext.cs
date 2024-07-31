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
        public DbSet<Regions> TblRegions { get; set; }
        public DbSet<Provinces> TblProvinces { get; set; }
        public DbSet<Municipalities> TblMunicipalities { get; set; }
        public DbSet<Barangays> TblBarangays { get; set; }
        public DbSet<SpeciesBreed> TblSpeciesBreed { get; set; }
        public DbSet<AnimalContact> TblAnimalContact { get; set; }
        public DbSet<TagType> TblTagType { get; set; }
        public DbSet<PetTagType> TblPetTagType { get; set; }

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
            modelBuilder.Entity<AnimalContact>().HasKey(ac => ac.AnimalContactID);
            modelBuilder.Entity<PetTagType>().HasKey(ptt=>ptt.TagID);
            modelBuilder.Entity<TagType>().HasKey(tt => tt.TagID);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetTagType>()
                .HasOne(a => a.TagType)
                .WithMany()
                .HasForeignKey(afc => afc.TagID);

            modelBuilder.Entity<PetTagType>()
               .HasOne(a => a.SpeciesGroup)
               .WithMany()
               .HasForeignKey(afc => afc.SpeciesCode);

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
            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.OwnershipTypeNavigation)
                .WithMany()
                .HasForeignKey(p => p.OwnershipType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.PetSexNavigation)
                .WithMany()
                .HasForeignKey(p => p.PetSexID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.AnimalFemaleClassNavigation)
                .WithMany()
                .HasForeignKey(p => p.AnimalFemaleClassID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.AnimalColorNavigation)
                .WithMany()
                .HasForeignKey(p => p.AnimalColorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.SpeciesGroupNavigation)
                .WithMany()
                .HasForeignKey(p => p.SpeciesCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.RegionsNavigation)
                .WithMany()
                .HasForeignKey(p => p.ClientRcode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.ProvincesNavigation)
                .WithMany()
                .HasForeignKey(p => p.ClientProvCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.MunicipalitiesNavigation)
                .WithMany()
                .HasForeignKey(p => p.ClientMunCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.BarangaysNavigation)
                .WithMany()
                .HasForeignKey(p => p.ClientBcode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PetRegistration.PetRegistration>()
                .HasOne(p => p.SpeciesBreedNavigation)
                .WithMany()
                .HasForeignKey(p => p.BreedID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
