using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models.PetRegistration
{
    public class Provinces
    {
        [Key]
        [Column("ProvCode")]
        [StringLength(50)]
        public string? ProvCode { get; set; }

        [Column("Rcode")]
        [StringLength(50)]
        public string? Rcode { get; set; }

        [Column("ProvinceName")]
        [StringLength(100)]
        public string? ProvinceName { get; set; }

        [Column("PSGC")]
        [StringLength(50)]
        public string? PSGC { get; set; }

        [Column("Old_Names")]
        [StringLength(100)]
        public string? OldNames { get; set; }

        [Column("Pop_2020")]
        public int? Population2020 { get; set; }

        // Navigation property
        public Regions? Regions { get; set; }
        public ICollection<Municipalities>? Municipalities { get; set; }
    }
}
