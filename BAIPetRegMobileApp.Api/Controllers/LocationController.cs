using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.DTOs;
using BAIPetRegMobileApp.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("regions")]
        public async Task<ActionResult<IEnumerable<RegionsDTO>>> GetRegions()
        {
            var regions = await _locationService.GetRegionsAsync();
            return Ok(regions);
        }

        [HttpGet("provinces/{regionCode}")]
        public async Task<ActionResult<IEnumerable<Provinces>>> GetProvincesByRegionCode(string regionCode)
        {
            var provinces = await _locationService.GetProvincesByRegionCodeAsync(regionCode);
            return Ok(provinces);
        }

        [HttpGet("municipalities/{provinceCode}")]
        public async Task<ActionResult<IEnumerable<Municipalities>>> GetMunicipalitiesByProvinceCode(string provinceCode)
        {
            var municipalities = await _locationService.GetMunicipalitiesByProvinceCodeAsync(provinceCode);
            return Ok(municipalities);
        }

        [HttpGet("barangays/{municipalityCode}")]
        public async Task<ActionResult<IEnumerable<BarangaysDTO>>> GetBarangaysByMunicipalityCode(string municipalityCode)
        {
            var barangays = await _locationService.GetBarangaysByMunicipalityCodeAsync(municipalityCode);
            return Ok(barangays);
        }

    }
}
