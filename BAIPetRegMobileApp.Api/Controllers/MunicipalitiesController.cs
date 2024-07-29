using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.Models.PetRegistration;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitiesController : BaseController<Municipalities, UserDbContext, string>
    {
        public MunicipalitiesController(UserDbContext context) : base(context) { }

        protected override string GetId(Municipalities entity) => entity.MunCode;

        protected override bool IdMatches(Municipalities entity, string id) => entity.MunCode == id;

        [HttpGet("by-province/{provcode}")]
        public async Task<ActionResult<IEnumerable<Municipalities>>> GetByProvince(string provcode)
        {
            var municipalities = await _context.TblMunicipalities.Where(m => m.ProvCode == provcode).ToListAsync();
            return Ok(municipalities);
        }
    }
}