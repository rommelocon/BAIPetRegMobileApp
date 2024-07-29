using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Data.User
{
    public class Barangays
    {
        [Key]
        [Column("Bcode")]
        [StringLength(50)]
        public string? Bcode { get; set; }

        [Column("Rcode")]
        [StringLength(50)]
        public string? Rcode { get; set; }

        [Column("ProvCode")]
        [StringLength(50)]
        public string? ProvCode { get; set; }

        [Column("MunCode")]
        [StringLength(50)]
        public string? MunCode { get; set; }

        [Column("PSGCID")]
        [StringLength(50)]
        public string? PSGCID { get; set; }

        [Column("BarangayName")]
        [StringLength(150)]
        public string? BarangayName { get; set; }

        [Column("OldBcode")]
        public double? OldBcode { get; set; }

        [Column("OldBryName")]
        [StringLength(150)]
        public string? OldBryName { get; set; }

        [Column("Pop2020")]
        public double? Population2020 { get; set; }

        // Navigation properties
        public Municipalities? Municipalities { get; set; }
    }
}