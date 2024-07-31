namespace BAIPetRegMobileApp.Models.User
{
    public class Regions
    {
        public string? Rcode { get; set; }
        public string? RegionName { get; set; }
        public string? PSGC { get; set; }
        public int? Population2020 { get; set; }
        public ICollection<Provinces>? TblProvinces { get; set; }
    }
}