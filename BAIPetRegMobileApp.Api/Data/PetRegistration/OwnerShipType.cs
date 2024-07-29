using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.PetRegistration
{
    public class OwnerShipType
    {
        [Key]
        public string? OwnerShipTypeID { get; set; }
        public string? OwnerShipDescription { get; set; }
    }
}