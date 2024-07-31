namespace BAIPetRegMobileApp.Models.User
{
    public class Municipalities
    {
        public string? MunCode { get; set; }
        public string? Rcode { get; set; }
        public string? ProvCode { get; set; }
        public string? MunCity { get; set; }
        public string? PSGC { get; set; }
        public string? GeographicLevel { get; set; }
        public string? OldNames { get; set; }
        public string? CityClass { get; set; }
        public string? IncomeClassification { get; set; }
        public double? Population2020 { get; set; }
        public Provinces? Provinces { get; set; }
        public ICollection<Barangays>? Barangays { get; set; }

    }
}
