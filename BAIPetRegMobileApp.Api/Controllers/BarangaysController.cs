using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangaysController : BaseController<TblBarangays, UserDbContext, string>
    {
        public BarangaysController(UserDbContext context) : base(context) { }

        protected override string GetId(TblBarangays entity) => entity.Bcode;

        protected override bool IdMatches(TblBarangays entity, string id) => entity.Bcode == id;

        [HttpGet("by-municipality/{muncode}")]
        public async Task<ActionResult<IEnumerable<TblBarangays>>> GetByMunicipality(string muncode)
        {
            var barangays = await _context.TblBarangays.Where(b => b.MunCode == muncode).ToListAsync();
            return Ok(barangays);
        }
    }
}
