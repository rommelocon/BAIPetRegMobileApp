using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.PetRegistration
{
    public class PetTagType
    {
        [Key]
        [StringLength(5)]
        public string? TagID { get; set; }

        [StringLength(50)]
        public string? TagDescription { get; set; }

        [StringLength(10)]
        public string? SpeciesCode { get; set; }

        [StringLength(50)]
        public string? SpeciesCommonName { get; set; }

        public virtual TagType? TagType { get; set; }
        public virtual SpeciesGroup? SpeciesGroup { get; set; }
    }
}
