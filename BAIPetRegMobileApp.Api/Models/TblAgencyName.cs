using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class TblAgencyName
    {
        [Key]
        [MaxLength(10)]
        public string AgencyID { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
