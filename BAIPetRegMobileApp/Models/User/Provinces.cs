namespace BAIPetRegMobileApp.Models.User
{
    public class Provinces
    {
        public string? ProvCode { get; set; }
        public string? Rcode { get; set; }
        public string? ProvinceName { get; set; }
        public string? PSGC { get; set; }
        public string? OldNames { get; set; }
        public int? Population2020 { get; set; }
        public Regions? Regions { get; set; }
        public ICollection<Municipalities>? Municipalities { get; set; }
    }
}
