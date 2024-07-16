using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAIPetRegMobileApp.Api.Models
{
    public class Municipality
    {
        [Key]
        [Column(TypeName = "NVARCHAR(50)")]
        public string? MunCode { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string? Rcode { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string? ProvCode { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string? MunCity { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string? PSGC { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string? GeographicLevel { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string? OldNames { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string? CityClass { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string? IncomeClassification { get; set; }

        public double? Pop2020 { get; set; }

        public ICollection<Barangay>? Barangays { get; set; }
    }
}