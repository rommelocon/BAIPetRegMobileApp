using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models.PetRegistration
{
    public class Regions
    {
        [Key]
        [Column("Rcode")]
        [StringLength(50)]
        public string? Rcode { get; set; }

        [Column("Region")]
        [StringLength(100)]
        public string? RegionName { get; set; }

        [Column("PSGC")]
        [StringLength(50)]
        public string? PSGC { get; set; }

        [Column("Pop_2020")]
        public int? Population2020 { get; set; }

        public ICollection<Provinces>? Provinces { get; set; }
    }
}