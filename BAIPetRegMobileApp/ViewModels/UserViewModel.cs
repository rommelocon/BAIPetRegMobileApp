namespace BAIPetRegMobileApp.ViewModels
{
    public class UserViewModel
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? MiddleName { get; set; }
        public string? ExtensionName { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? SexDescription { get; set; }
        public string? MobileNumber { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Region { get; set; }
        public string? ProvinceName { get; set; }
        public string? MunicipalitiesCities { get; set; }
        public string? BarangayName { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? CivilStatusName { get; set; }
        public string? StreetNumber { get; set; }
        public string? FullAddress { get; set; }
        // add other fields as needed
    }
}