using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models.PetRegistration
{
    public class AnimalFemaleClassification
    {
        [Key]
        public int AnimalFemaleClassID { get; set; }
        public string? AnimalFemalClassification { get; set; }
    }
}
