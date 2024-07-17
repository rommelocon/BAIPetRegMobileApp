using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAIPetRegMobileApp.Api.Models
{
    public class Barangay
    {
        [Key]
        [StringLength(50)]
        public string? Bcode { get; set; }

        [StringLength(50)]
        public string? Rcode { get; set; }

        [StringLength(50)]
        public string? ProvCode { get; set; }

        [StringLength(50)]
        public string? MunCode { get; set; }

        [StringLength(50)]
        public string? PSGCID { get; set; }

        [StringLength(150)]
        public string? BarangayName { get; set; }

        public double? OldBcode { get; set; }

        [StringLength(150)]
        public string? OldBryName { get; set; }

        public double? Pop2020 { get; set; }

        // Foreign key reference
        [ForeignKey("MunCode")]
        public Municipality? Municipality { get; set; }

        // Navigation properties
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
