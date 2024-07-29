using BAIPetRegMobileApp.Api.Models.PetRegistration;
using BAIPetRegMobileApp.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class PetRegistrationController : ControllerBase
{
    private readonly PetRegistrationService _service;

    public PetRegistrationController(PetRegistrationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PetRegistrationDto>>> Get()
    {
        var registrations = await _service.GetAllAsync();
        return Ok(registrations);
    }

    [HttpGet("{petRegistrationID}")]
    public async Task<ActionResult<PetRegistrationDto>> Get(string petRegistrationID)
    {
        var registration = await _service.GetByIdAsync(petRegistrationID);
        if (registration == null) return NotFound();

        return Ok(registration);
    }

    [HttpPost]
    public async Task<ActionResult<PetRegistrationDto>> Post(PetRegistrationDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID from the claims

        if (userId == null)
        {
            return Unauthorized(); // Return Unauthorized if user ID is not found
        }

        var createdRegistration = await _service.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(Get), new { petRegistrationID = createdRegistration.PetRegistrationID }, createdRegistration);
    }

    [HttpPut("{petRegistrationID}")]
    public async Task<IActionResult> Put(string petRegistrationID, PetRegistrationDto dto)
    {
        var updated = await _service.UpdateAsync(petRegistrationID, dto);
        if (!updated) return NotFound();

        return NoContent();
    }

    [HttpDelete("{petRegistrationID}")]
    public async Task<IActionResult> Delete(string petRegistrationID)
    {
        var deleted = await _service.DeleteAsync(petRegistrationID);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
