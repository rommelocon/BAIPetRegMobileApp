namespace BAIPetRegMobileApp.Models.PetRegistration
{
    public class SpeciesBreed
    {
        public string? BreedID { get; set; }
        public string? BreedDescription { get; set; }
        public int? BreedIDNumber { get; set; }
        public string? SpeciesCode { get; set; }
        public string? SpeciesCommonName { get; set; }

        public SpeciesGroup? SpeciesGroup { get; set; }
    }
}
