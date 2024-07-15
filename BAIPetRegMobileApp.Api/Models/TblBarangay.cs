using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models
{
    public class TblBarangay
    {
        [Key]
        [MaxLength(50)]
        public string Bcode { get; set; }
        public string BarangayName { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
