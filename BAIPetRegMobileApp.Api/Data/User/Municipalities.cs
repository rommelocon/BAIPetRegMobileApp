using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.User
{
    public class Municipalities
    {
        [Key]
        [Column("MunCode")]
        [StringLength(50)]
        public string? MunCode { get; set; }

        [Column("Rcode")]
        [StringLength(50)]
        public string? Rcode { get; set; }

        [Column("ProvCode")]
        [StringLength(50)]
        public string? ProvCode { get; set; }

        [Column("MunCity")]
        [StringLength(150)]
        public string? MunCity { get; set; }

        [Column("PSGC")]
        [StringLength(50)]
        public string? PSGC { get; set; }

        [Column("GeographicLevel")]
        [StringLength(150)]
        public string? GeographicLevel { get; set; }

        [Column("OldNames")]
        [StringLength(150)]
        public string? OldNames { get; set; }

        [Column("CityClass")]
        [StringLength(50)]
        public string? CityClass { get; set; }

        [Column("IncomeClassification")]
        [StringLength(50)]
        public string? IncomeClassification { get; set; }

        [Column("Pop2020")]
        public double? Population2020 { get; set; }

        // Navigation properties
        public Provinces? Provinces { get; set; }


        // Add this navigation property
        public ICollection<Barangays>? Barangays { get; set; }

    }
}