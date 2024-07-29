using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.PetRegistration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesBreedController : BaseController<SpeciesBreed, PetRegistrationDbContext, string>
    {
        public SpeciesBreedController(PetRegistrationDbContext context) : base(context) { }

        protected override string GetId(SpeciesBreed entity) => entity.BreedID!;

        protected override bool IdMatches(SpeciesBreed entity, string id) => entity.BreedID == id;

        [HttpGet("{speciesCommonName}")]
        public async Task<ActionResult<IEnumerable<SpeciesBreed>>> GetBySpeciesCode(string speciesCommonName)
        {
            var speciesBreeds = await _context.TblSpeciesBreed.Where(p => p.SpeciesCommonName == speciesCommonName).ToListAsync();
            return Ok(speciesBreeds);
        }
    }
}
