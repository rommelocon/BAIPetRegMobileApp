using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly UserDbContext userDbContext;

        public RegionsController(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        // GET: api/TblRegions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRegions>>> GetTblRegions()
        {
            return await userDbContext.TblRegions.ToListAsync();
        }

        // GET: api/TblRegions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRegions>> GetTblRegions(string id)
        {
            var tblRegions = await userDbContext.TblRegions.FindAsync(id);

            if (tblRegions == null)
            {
                return NotFound();
            }

            return tblRegions;
        }
    }
}
