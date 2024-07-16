using BAIPetRegMobileApp.Api.Models;
using BAIPetRegMobileApp.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        private readonly IJwtUtils jwtUtils;

        private readonly IConfiguration configuration;
        //Both UserManager and SignInManager services are injected into the AccountController
        //using constructor injection
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IJwtUtils jwtUtils)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.jwtUtils = jwtUtils;
        }

        [HttpGet("{username}")]
        [Authorize]
        public async Task<IActionResult> GetProfile(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {   
                return NotFound();
            }

            var profile = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                CivilStatusCode = user.CivilStatusCode,
                Birthday = user.Birthday,
                SexID = user.SexID,
                MobileNumber = user.MobileNumber,
                Region = user.Region,
                ProvinceName = user.ProvinceName,
                MunicipalitiesCities = user.MunicipalitiesCities,
                BarangayName = user.BarangayName,
                // add other fields as needed
            };

            return Ok(profile);
        }

        [HttpPut("{username}")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(string username, [FromBody] ProfileViewModel model)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            user.Email = model.Email;
            user.Firstname = model.FirstName!;
            user.Lastname = model.LastName!;
            // update other fields as needed

            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser
            { 
                UserName = model.UserName, 
                Email = model.Email,
                DateRegistered = DateTime.UtcNow // Set the registration date
            };

            var result = await userManager.CreateAsync(user, model.Password!);
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
            var result = await signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.UserName!);
                var accessToken = jwtUtils.GenerateToken(user!);
                var refreshToken = jwtUtils.GenerateRefreshToken();

                return Ok(new
                {
                    refreshToken,
                    accessToken,
                    userName = model.UserName,
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
