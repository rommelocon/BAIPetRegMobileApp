using BAIPetRegMobileApp.Api.Models;
using BAIPetRegMobileApp.Api.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //userManager will hold the UserManager instance
        private readonly UserManager<ApplicationUser> userManager;
        //signInManager will hold the SignInManager instance
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly IConfiguration configuration;
        private TokenService tokenService;

        //Both UserManager and SignInManager services are injected into the AccountController
        //using constructor injection
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            tokenService = new TokenService(configuration);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var accessToken = tokenService.GenerateJwtToken(model);
                var refreshToken = tokenService.GenerateRefreshToken();
                var tokenExpiresIn = tokenService.GetTokenExpiration(accessToken);

                return Ok(new
                {
                    tokenType = "Bearer", // or your token type
                    accessToken,
                    expiresIn = 3600,
                    refreshToken
                });
            }

            if (result.IsLockedOut)
            {
                return Unauthorized("User account locked out.");
            }

            return Unauthorized("Invalid login attempt.");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
                return Ok("User logged out successful");
            }
            return BadRequest("You are not logged in");
          
        }

        [HttpGet("user")]
        public async Task<ActionResult<ApplicationUser>> GetUserInfo()
        {
            var user = await userManager.GetUserAsync(User); // Get the current authenticated user
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
