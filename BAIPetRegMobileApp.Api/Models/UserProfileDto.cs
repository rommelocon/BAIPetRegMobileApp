namespace BAIPetRegMobileApp.Api.Models
{
    public class UserProfileDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Middlename { get; set; }
        public string? Fullname { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Birthday { get; set; }  // This will be a formatted string
        public string? MobileNumber { get; set; }
        public string? Region { get; set; }
        public string? ProvinceName { get; set; }
        public string? MunicipalitiesCities { get; set; }
        public string? BarangayName { get; set; }
        // Add other fields as needed
    }
}
