using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.PetRegistration; // Ensure this namespace matches where your models are located

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesGroupController : BaseController<SpeciesGroup, PetRegistrationDbContext, string>
    {
        public SpeciesGroupController(PetRegistrationDbContext context) : base(context)
        {
        }

        protected override string GetId(SpeciesGroup entity)
        {
            return entity.SpeciesCode!;
        }

        protected override bool IdMatches(SpeciesGroup entity, string id)
        {
            return entity.SpeciesCode == id;
        }

        // Override GetAll to filter dogs and cats
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<SpeciesGroup>>> GetAll()
        {
            var speciesGroups = await _context.TblSpeciesGroup
                .Where(sg => sg.SpeciesCommonName == "Dog" || sg.SpeciesCommonName == "Cat")
                .ToListAsync();

            return Ok(speciesGroups);
        }
    }
}
