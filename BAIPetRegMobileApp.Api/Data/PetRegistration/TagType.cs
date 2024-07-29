using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.PetRegistration
{
    public class TagType
    {
        [Key]
        [StringLength(5)]
        public string? TagID { get; set; }

        [StringLength(50)]
        public string? TagDescription { get; set; }
    }
}
