namespace BAIPetRegMobileApp.Api.Data.User
{
    public class Login
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public required bool RememberMe { get; set; }
    }
}