using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Models
{
    public class TblRegions
    {
        [Key]
        [Column("Rcode")]
        [StringLength(50)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Rcode { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Column("Region")]
        [StringLength(100)]
        public string? RegionName { get; set; }

        [Column("PSGC")]
        [StringLength(50)]
        public string? PSGC { get; set; }

        [Column("Pop_2020")]
        public int? Population2020 { get; set; }

        // Navigation property
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ICollection<TblProvinces> TblProvinces { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
