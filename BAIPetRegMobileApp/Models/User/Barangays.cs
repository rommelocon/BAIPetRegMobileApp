namespace BAIPetRegMobileApp.Models.User
{
    public class Barangays
    {
        public string? Bcode { get; set; }
        public string? Rcode { get; set; }
        public string? ProvCode { get; set; }
        public string? MunCode { get; set; }
        public string? PSGCID { get; set; }
        public string? BarangayName { get; set; }
        public double? OldBcode { get; set; }
        public string? OldBryName { get; set; }
        public double? Population2020 { get; set; }
        public Municipalities? Municipalities { get; set; }
    }
}
