namespace BAIPetRegMobileApp.Api.Models;
public class User
{
    public required string Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
}