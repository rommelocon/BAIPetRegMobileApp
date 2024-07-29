using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models.PetRegistration
{
    public class OwnerShipType
    {
        [Key]
        public string? OwnerShipTypeID { get; set; }
        public string? OwnerShipDescription { get; set; }
    }
}