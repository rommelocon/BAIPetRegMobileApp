using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class OptionsController : ControllerBase
    {
        private readonly UserDbContext _context;

        public OptionsController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet("regions")]
        public async Task<ActionResult<List<string>>> GetRegions()
        {
            var regionNames = await _context.TblRegions
                                            .Select(r => r.RegionName)
                                            .ToListAsync();

            if (regionNames == null || regionNames.Count == 0)
            {
                return NotFound("No regions found.");
            }

            return Ok(regionNames);
        }

        [HttpGet("provinces")]
        public async Task<ActionResult<IEnumerable<string>>> GetProvinces([FromQuery] string regionCode)
        {
            return await _context.TblProvinces.Where(p => p.Rcode == regionCode).Select(p => p.ProvinceName).ToListAsync();
        }

        [HttpGet("municipalities")]
        public async Task<ActionResult<IEnumerable<string>>> GetMunicipalities([FromQuery] string provinceCode)
        {
            return await _context.TblMunicipalities.Where(m => m.ProvCode == provinceCode).Select(m => m.MunCity).ToListAsync();
        }

        [HttpGet("barangays")]
        public async Task<ActionResult<IEnumerable<string>>> GetBarangays([FromQuery] string municipalityCode)
        {
            return await _context.TblBarangays.Where(b => b.MunCode == municipalityCode).Select(b => b.BarangayName).ToListAsync();
        }

        // New endpoints to get codes based on names
        [HttpGet("regions/code")]
        public async Task<ActionResult<string>> GetRegionCode([FromQuery] string name)
        {
            var region = await _context.TblRegions.FirstOrDefaultAsync(r => r.RegionName == name);
            if (region == null) return NotFound();
            return region.Rcode;
        }

        [HttpGet("provinces/code")]
        public async Task<ActionResult<string>> GetProvinceCode([FromQuery] string name)
        {
            var province = await _context.TblProvinces.FirstOrDefaultAsync(p => p.ProvinceName == name);
            if (province == null) return NotFound();
            return province.ProvCode;
        }

        [HttpGet("municipalities/code")]
        public async Task<ActionResult<string>> GetMunicipalityCode([FromQuery] string name)
        {
            var municipality = await _context.TblMunicipalities.FirstOrDefaultAsync(m => m.MunCity == name);
            if (municipality == null) return NotFound();
            return municipality.MunCode;
        }
    }


}
