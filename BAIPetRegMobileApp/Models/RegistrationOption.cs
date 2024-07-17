using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAIPetRegMobileApp.Api.Models
{
    public class RegistrationOption
    {
        [Key]
        public int? RegOptID { get; set; }

        [StringLength(50)]
        public string? RegOptDescription { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
