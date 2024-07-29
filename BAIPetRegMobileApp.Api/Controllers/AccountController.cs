using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.DTOs;
using BAIPetRegMobileApp.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJWTConfiguration _jwtUtils;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJWTConfiguration jwtUtils)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtUtils = jwtUtils;
        }

        [HttpPut("user")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UserDTO model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Update the user details
            UpdateUserFromDTO(user, model);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName!);
                var accessToken = _jwtUtils.GenerateToken(user!);
                var refreshToken = _jwtUtils.GenerateRefreshToken();

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
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("User logged out successfully");
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetUserInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(MapUserToViewModel(user));
        }

        private UserDTO MapUserToViewModel(ApplicationUser user)
        {
            return new UserDTO
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                MiddleName = user.MiddleName,
                ExtensionName = user.ExtensionName,
                Birthday = user.Birthday,
                SexDescription = user.SexDescription,
                MobileNumber = user.MobileNumber,
                UserName = user.UserName,
                Email = user.Email,
                Region = user.Region,
                ProvinceName = user.ProvinceName,
                MunicipalitiesCities = user.MunicipalitiesCities,
                BarangayName = user.BarangayName,
                FullAddress = user.FullAddress,
                ProfilePicture = user.ProfilePicture,
            };
        }

        private void UpdateUserFromDTO(ApplicationUser user, UserDTO model)
        {
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            user.MiddleName = model.MiddleName;
            user.ExtensionName = model.ExtensionName;
            user.Birthday = model.Birthday;
            user.SexDescription = model.SexDescription;
            user.MobileNumber = model.MobileNumber;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Region = model.Region;
            user.ProvinceName = model.ProvinceName;
            user.MunicipalitiesCities = model.MunicipalitiesCities;
            user.BarangayName = model.BarangayName;
            user.FullAddress = model.FullAddress;
            user.ProfilePicture = model.ProfilePicture;
            // Update other properties as needed
        }
    }
}
