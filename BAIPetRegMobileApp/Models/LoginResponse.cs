using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Models;
public class LoginResponse
{
    [Required]
    [Display(Name = "accessToken")]
    public string? AccessToken { get; set; }
    [Required]
    [Display(Name = "refreshToken")]
    public string? RefreshToken { get; set; }
    [Required]
    [Display(Name = "userName")]
    public string? UserName { get; set;}
}