using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.Models.PetRegistration;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangaysController : BaseController<Barangays, UserDbContext, string>
    {
        public BarangaysController(UserDbContext context) : base(context) { }

        protected override string GetId(Barangays entity) => entity.Bcode;

        protected override bool IdMatches(Barangays entity, string id) => entity.Bcode == id;

        [HttpGet("by-municipality/{muncode}")]
        public async Task<ActionResult<IEnumerable<Barangays>>> GetByMunicipality(string muncode)
        {
            var barangays = await _context.TblBarangays.Where(b => b.MunCode == muncode).ToListAsync();
            return Ok(barangays);
        }
    }
}