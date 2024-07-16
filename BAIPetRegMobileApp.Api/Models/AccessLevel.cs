using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class AccessLevel
    {
        [Key]
        public int? AccessLevelID { get; set; }

        [StringLength(50)]
        public string? AccessLevelDescription { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
