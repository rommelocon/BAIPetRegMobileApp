using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class TblSexType
    {
        [Key]
        public int SexID { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
