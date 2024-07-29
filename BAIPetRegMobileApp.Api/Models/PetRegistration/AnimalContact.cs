using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models.PetRegistration
{
    public class AnimalContact
    {
        [Key]
        public int AnimalContactID { get; set; }

        [StringLength(50)]
        public string? AnimalContactDescription { get; set; }
    }
}
