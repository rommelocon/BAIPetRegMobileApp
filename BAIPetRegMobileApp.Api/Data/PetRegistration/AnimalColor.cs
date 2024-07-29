using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.PetRegistration
{
    public class AnimalColor
    {
        [Key]
        [StringLength(10)]
        public string? AnimalColorID { get; set; }

        [StringLength(50)]
        public string? AnimalColorDescription { get; set; }
    }
}
