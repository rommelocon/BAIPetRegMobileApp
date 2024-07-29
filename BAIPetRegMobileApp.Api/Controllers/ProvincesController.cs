using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.Models.PetRegistration;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : BaseController<Provinces, UserDbContext, string>
    {
        public ProvincesController(UserDbContext context) : base(context) { }

        protected override string GetId(Provinces entity) => entity.ProvCode;

        protected override bool IdMatches(Provinces entity, string id) => entity.ProvCode == id;

        [HttpGet("by-region/{rcode}")]
        public async Task<ActionResult<IEnumerable<Provinces>>> GetByRegion(string rcode)
        {
            var provinces = await _context.TblProvinces.Where(p => p.Rcode == rcode).ToListAsync();
            return Ok(provinces);
        }
    }

}