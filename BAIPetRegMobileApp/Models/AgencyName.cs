using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class AgencyName
    {
        [Key]
        [StringLength(10)]
        public string? AgencyID { get; set; }

        [StringLength(50)]
        public string? AgencyDescription { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
