namespace BAIPetRegMobileApp.Models.PetRegistration
{
    public class SpeciesGroup
    {
        public string? SpeciesCode { get; set; }
        public string? SpeciesCommonName { get; set; }
        public string? ScientificDescription { get; set; }
        public int? SpeciesID { get; set; }
        public bool? Active { get; set; }
        public virtual ICollection<SpeciesBreed>? Breeds { get; set; }
    }
}
