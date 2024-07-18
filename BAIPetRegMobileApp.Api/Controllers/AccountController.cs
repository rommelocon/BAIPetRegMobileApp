﻿using BAIPetRegMobileApp.Api.Models;
using BAIPetRegMobileApp.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtUtils jwtUtils) : ControllerBase
    {
        [HttpGet("profile/{username}")]
        [Authorize]
        public async Task<IActionResult> GetProfile(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(MapUserToProfileViewModel(user));
        }

        [HttpPut("profile/{username}")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(string username)
        {
            //First Fetch the User Details by UserId
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            //Store all the information in the EditUserViewModel instance
            var model = new UserViewModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                MiddleName = user.MiddleName,
                ExtensionName = user.ExtensionName,
                Birthday = user.Birthday,
                SexDescription = user.SexDescription,
                Email = user.Email,
                CivilStatusName = user.CivilStatusName,
                MobileNumber = user.MobileNumber,
                Region = user.Region,
                ProvinceName = user.ProvinceName,
                MunicipalitiesCities = user.MunicipalitiesCities,
                BarangayName = user.BarangayName,
                // Add other properties as needed
            };

            return Ok(model);
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

            return BadRequest(result.Errors);
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
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("User logged out successfully");
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<ActionResult<ApplicationUser>> GetUserInfo()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        private static UserViewModel MapUserToProfileViewModel(ApplicationUser user)
        {
            return new UserViewModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                MiddleName = user.MiddleName,
                ExtensionName = user.ExtensionName,
                Birthday = user.Birthday, // Assuming ApplicationUser has a DateOnly property for Birthday
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
                CivilStatusName = user.CivilStatusName,
                // Map other properties as needed
            };
        }
    }
}
