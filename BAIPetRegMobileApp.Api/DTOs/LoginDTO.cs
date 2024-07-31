namespace BAIPetRegMobileApp.Api.DTOs
{
    public class LoginDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public required bool RememberMe { get; set; }
    }
}