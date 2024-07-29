using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Data.PetRegistration;
using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetRegistrationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly PetRegistrationDbContext _context;

        public PetRegistrationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            PetRegistrationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost("register-pet")]
        public async Task<IActionResult> RegisterPet([FromBody] PetRegistrationDTO model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (model == null)
            {
                return BadRequest("Invalid pet registration data.");
            }

            // Validate PetSexID and AnimalFemaleClassID relationship
            if (model.PetSexID == 2)
            {
                if (model.AnimalFemaleClassID == 0 || !await _context.TblAnimalFemalClassification.AnyAsync(c => c.AnimalFemaleClassID == model.AnimalFemaleClassID))
                {
                    return BadRequest("Invalid AnimalFemaleClassID for the selected pet sex.");
                }
            }

            // Create a new PetRegistration entity
            var petRegistration = new PetRegistration
            {
                DateEncocde = model.DateEncocde,
                DateRegistered = model.DateRegistered,
                TagID = model.TagID,
                TagDescription = model.TagDescription,
                TagNo = model.TagNo,
                Alias = model.Alias,
                ClientID = user.Id,
                ClientName = $"{user.Firstname} {user.Lastname}",
                ClientSexID = user.SexID,
                ClientSexDescription = user.SexDescription,
                ClientRcode = user.RcodeNum,
                ClientRegion = user.Region,
                ClientProvCode = user.PcodeNum,
                ClientProvinceName = user.ProvinceName,
                ClientMunCode = user.McodeNum,
                ClientMunicipalities = user.MunicipalitiesCities,
                ClientBcode = user.Bcode,
                ClientBarangayName = user.BarangayName,
                OwnershipType = model.OwnershipType,
                OwnershipTypeDescription = model.OwnershipDescription,
                PetName = model.PetName,
                PetDateofBirth = model.PetDateofBirth,
                PetSexID = model.PetSexID,
                PetSexDescription = model.PetSexDescription,
                AnimalFemaleClassID = model.PetSexID == 1 ? model.AnimalFemaleClassID : (int?)null, // Set only if female
                AnimalFemalClassification = model.PetSexID == 1 ? model.AnimalFemalClassification : null,
                NumberOffspring = model.NumberOffspring,
                Weight = model.Weight,
                AgeInMonth = model.AgeInMonth,
                SpeciesCode = model.SpeciesCode,
                SpeciesCommonName = model.SpeciesCommonName,
                BreedID = model.BreedID,
                BreedDescription = model.BreedDescription,
                AnimalColorID = model.AnimalColorID,
                AnimalColorDescription = model.AnimalColorDescription,
                PetOrigin = model.PetOrigin,
                StatusID = model.StatusID,
                StatusDescription = model.StatusDescription,
                DateDied = model.DateDied,
                ReportOfficer = model.ReportOfficer,
                PetImage1 = model.PetImage1,
                PetImage2 = model.PetImage2,
                PetImage3 = model.PetImage3,
                PetImage4 = model.PetImage4,
                UserName = user.UserName,
                Remarks = model.Remarks
            };

            // Add to the database
            _context.TblPetRegistration.Add(petRegistration);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log and handle the exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex}: An error occurred while saving the pet registration.");
            }

            return Ok("Pet registration successful.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPetRegistration(string id)
        {
            var petRegistration = await _context.TblPetRegistration.FindAsync(id);
            if (petRegistration == null)
            {
                return NotFound();
            }

            return Ok(petRegistration);
        }
    }
}