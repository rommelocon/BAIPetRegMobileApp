using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class TblRegistrationOption
    {
        [Key]
        public int RegOptID { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
