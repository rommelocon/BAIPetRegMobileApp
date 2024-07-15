using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class TblAccessLevel
    {
        [Key]
        public int AccessLevelID { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
