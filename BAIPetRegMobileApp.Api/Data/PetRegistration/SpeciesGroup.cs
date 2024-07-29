using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.PetRegistration
{
    public class SpeciesGroup
    {
        [Key]
        [StringLength(10)]
        public string? SpeciesCode { get; set; }

        [StringLength(100)]
        public string? SpeciesCommonName { get; set; }

        [StringLength(150)]
        public string? ScientificDescription { get; set; }

        public int? SpeciesID { get; set; }

        public bool? Active { get; set; }

        public virtual ICollection<SpeciesBreed>? Breeds { get; set; }
    }
}
