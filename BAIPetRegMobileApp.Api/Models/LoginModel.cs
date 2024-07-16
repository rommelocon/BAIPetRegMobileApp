using System.ComponentModel.DataAnnotations;

namespace BAIPetRegMobileApp.Api.Models;
public class LoginModel
{
    [Required]
    [Display(Name = "Username")]
    public string? UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Remember Me")]
    public required bool RememberMe { get; set; }
}