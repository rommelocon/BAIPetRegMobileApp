using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitiesController : BaseController<TblMunicipalities, UserDbContext, string>
    {
        public MunicipalitiesController(UserDbContext context) : base(context) { }

        protected override string GetId(TblMunicipalities entity) => entity.MunCode;

        protected override bool IdMatches(TblMunicipalities entity, string id) => entity.MunCode == id;

        [HttpGet("by-province/{provcode}")]
        public async Task<ActionResult<IEnumerable<TblMunicipalities>>> GetByProvince(string provcode)
        {
            var municipalities = await _context.TblMunicipalities.Where(m => m.ProvCode == provcode).ToListAsync();
            return Ok(municipalities);
        }
    }
}