using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : BaseController<TblProvinces, UserDbContext, string>
    {
        public ProvincesController(UserDbContext context) : base(context) { }

        protected override string GetId(TblProvinces entity) => entity.ProvCode;

        protected override bool IdMatches(TblProvinces entity, string id) => entity.ProvCode == id;

        [HttpGet("by-region/{rcode}")]
        public async Task<ActionResult<IEnumerable<TblProvinces>>> GetByRegion(string rcode)
        {
            var provinces = await _context.TblProvinces.Where(p => p.Rcode == rcode).ToListAsync();
            return Ok(provinces);
        }
    }

}
