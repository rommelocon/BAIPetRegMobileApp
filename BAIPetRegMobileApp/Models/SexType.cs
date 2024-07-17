using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class SexType
    {
        [Key]
        public int? SexID { get; set; }

        [StringLength(50)]
        public string? SexDescription { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
