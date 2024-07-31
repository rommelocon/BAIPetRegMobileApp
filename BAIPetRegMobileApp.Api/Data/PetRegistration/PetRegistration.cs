using BAIPetRegMobileApp.Api.Data.User;

namespace BAIPetRegMobileApp.Api.Data.PetRegistration
{
    public class PetRegistration
    {
        public string? PetRegistrationID { get; set; }
        public DateTime? DateEncocde { get; set; }
        public DateTime? DateRegistered { get; set; }
        public string? TagID { get; set; }
        public string? TagDescription { get; set; }
        public string? TagNo { get; set; }
        public string? Alias { get; set; }
        public string? ClientID { get; set; }
        public string? ClientName { get; set; }
        public int? ClientSexID { get; set; }
        public string? ClientSexDescription { get; set; }
        public string? ClientRcode { get; set; }
        public string? ClientRegion { get; set; }
        public string? ClientProvCode { get; set; }
        public string? ClientProvinceName { get; set; }
        public string? ClientMunCode { get; set; }
        public string? ClientMunicipalities { get; set; }
        public string? ClientBcode { get; set; }
        public string? ClientBarangayName { get; set; }
        public string? OwnershipType { get; set; }
        public string? OwnershipTypeDescription { get; set; }
        public string? PetName { get; set; }
        public DateTime? PetDateofBirth { get; set; }
        public int? PetSexID { get; set; }
        public string? PetSexDescription { get; set; }
        public int? AnimalFemaleClassID { get; set; }
        public string? AnimalFemalClassification { get; set; }
        public int? NumberOffspring { get; set; }
        public double? Weight { get; set; }
        public double? AgeInMonth { get; set; }
        public string? SpeciesCode { get; set; }
        public string? SpeciesCommonName { get; set; }
        public string? BreedID { get; set; }
        public string? BreedDescription { get; set; }
        public string? AnimalColorID { get; set; }
        public string? AnimalColorDescription { get; set; }
        public string? PetOrigin { get; set; }
        public int? StatusID { get; set; }
        public string? StatusDescription { get; set; }
        public DateTime? DateDied { get; set; }
        public string? ReportOfficer { get; set; }
        public string? PetImage1 { get; set; }
        public string? PetImage2 { get; set; }
        public string? PetImage3 { get; set; }
        public string? PetImage4 { get; set; }
        public string? UserName { get; set; }
        public string? Remarks { get; set; }

        // Navigation properties
        public virtual OwnerShipType? OwnershipTypeNavigation { get; set; }
        public virtual SexType? PetSexNavigation { get; set; }
        public virtual AnimalFemaleClassification? AnimalFemaleClassNavigation { get; set; }
        public virtual AnimalColor? AnimalColorNavigation { get; set; }
        public virtual SpeciesGroup? SpeciesGroupNavigation { get; set; }
        public virtual Regions? RegionsNavigation { get; set; }
        public virtual Provinces? ProvincesNavigation { get; set; }
        public virtual Municipalities? MunicipalitiesNavigation { get; set; }
        public virtual Barangays? BarangaysNavigation { get; set; }
        public virtual SpeciesBreed? SpeciesBreedNavigation { get; set; }
    }
}
