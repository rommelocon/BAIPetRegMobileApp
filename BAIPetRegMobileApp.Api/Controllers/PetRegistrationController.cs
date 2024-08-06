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
        private readonly PetRegistrationDbContext _context;

        public PetRegistrationController(UserManager<ApplicationUser> userManager, PetRegistrationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPet([FromBody] PetRegistrationDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User is not authenticated.");

            var petRegistration = new PetRegistration
            {
                PetRegistrationID = Guid.NewGuid().ToString(),
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
                OwnershipTypeDescription = model.OwnershipTypeDescription,
                PetName = model.PetName,
                PetDateofBirth = model.PetDateofBirth,
                PetSexID = model.PetSexID,
                PetSexDescription = model.PetSexDescription,
                AnimalFemaleClassID = model.PetSexID == 2 ? model.AnimalFemaleClassID : (int?)null,
                AnimalFemalClassification = model.PetSexID == 2 ? model.AnimalFemalClassification : null,
                NumberOffspring = model.NumberOffspring,
                Weight = model.Weight,
                AgeInMonth = CalculateAgeInMonths(model.PetDateofBirth),
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

            // Method to calculate the age in months
            int CalculateAgeInMonths(DateTime? birthDate)
            {
                var today = DateTime.Today;
                int ageInMonths = (today.Year - birthDate!.Value.Year) * 12 + today.Month - birthDate.Value.Month;

                // If the birth date hasn't occurred yet this month, subtract 1
                if (today.Day < birthDate.Value.Day)
                {
                    ageInMonths--;
                }

                return ageInMonths;
            }

            try
            {
                _context.TblPetRegistration.Add(petRegistration);
                await _context.SaveChangesAsync();
                return Ok("Pet registration successful.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex}: An error occurred while saving the pet registration.");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPetRegistration()
        {
            var userId = _userManager.GetUserId(User);
            var petRegistrations = await _context.TblPetRegistration
                .Where(p => p.ClientID == userId)
                .AsNoTracking()
                .OrderByDescending(p => p.DateRegistered)
                .ToListAsync();

            if (!petRegistrations.Any())
                return NotFound();

            return Ok(petRegistrations);
        }

        [HttpGet("{petId}")]
        [Authorize]
        public async Task<IActionResult> GetPetRegistration(string petId)
        {
            var userId = _userManager.GetUserId(User);
            var petRegistration = await _context.TblPetRegistration
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ClientID == userId && p.PetRegistrationID == petId);

            if (petRegistration == null)
                return NotFound();

            return Ok(petRegistration);
        }

        [HttpGet("ownershipType")]
        public async Task<ActionResult<IEnumerable<OwnerShipType>>> GetOwnerShipType() =>
            await _context.TblOwnerShipType.AsNoTracking().ToListAsync();

        [HttpGet("animalColor")]
        public async Task<ActionResult<IEnumerable<AnimalColor>>> GetAnimalColor() =>
            await _context.TblAnimalColor.AsNoTracking().ToListAsync();

        [HttpGet("animalContacts")]
        public async Task<ActionResult<IEnumerable<AnimalContact>>> GetAnimalContact() =>
            await _context.TblAnimalContact.AsNoTracking().ToListAsync();

        [HttpGet("animalFemaleClassificator")]
        public async Task<ActionResult<IEnumerable<AnimalFemaleClassification>>> GetAnimalFemaleClassificator() =>
            await _context.TblAnimalFemalClassification.AsNoTracking().ToListAsync();

        [HttpGet("petTagType")]
        public async Task<ActionResult<IEnumerable<PetTagType>>> GetPetTagType() =>
            await _context.TblPetTagType.AsNoTracking().ToListAsync();

        [HttpGet("speciesBreed/{speciesCode}")]
        public async Task<ActionResult<IEnumerable<SpeciesBreed>>> GetSpeciesBreed(string speciesCode) =>
            await _context.TblSpeciesBreed
                .Where(e => e.SpeciesCode == speciesCode)
                .AsNoTracking()
                .ToListAsync();

        [HttpGet("speciesGroup")]
        public async Task<ActionResult<IEnumerable<SpeciesGroup>>> GetSpeciesGroup() =>
            await _context.TblSpeciesGroup
                .Where(e => e.SpeciesCommonName == "Dog" || e.SpeciesCommonName == "Cat")
                .AsNoTracking()
                .ToListAsync();

        [HttpGet("tagType")]
        public async Task<ActionResult<IEnumerable<TagType>>> GetTagType() =>
            await _context.TblTagType.AsNoTracking().ToListAsync();
    }
}
