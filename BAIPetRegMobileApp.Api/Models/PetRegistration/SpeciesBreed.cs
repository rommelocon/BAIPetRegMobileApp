using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models.PetRegistration
{
    public class SpeciesBreed
    {
        [Key]
        [StringLength(10)]
        public string? BreedID { get; set; }

        [StringLength(100)]
        public string? BreedDescription { get; set; }

        public int? BreedIDNumber { get; set; }

        [StringLength(50)]
        public string? SpeciesCode { get; set; }

        [StringLength(100)]
        public string? SpeciesCommonName { get; set; }

        public SpeciesGroup? SpeciesGroup { get; set; }
    }
}
