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
            => Ok(await _locationService.GetRegionsAsync());

        [HttpGet("provinces/{regionCode}")]
        public async Task<ActionResult<IEnumerable<ProvincesDTO>>> GetProvincesByRegionCode(string regionCode)
            => Ok(await _locationService.GetProvincesByRegionCodeAsync(regionCode));

        [HttpGet("municipalities/{provinceCode}")]
        public async Task<ActionResult<IEnumerable<MunicipalitiesDTO>>> GetMunicipalitiesByProvinceCode(string provinceCode)
            => Ok(await _locationService.GetMunicipalitiesByProvinceCodeAsync(provinceCode));

        [HttpGet("barangays/{municipalityCode}")]
        public async Task<ActionResult<IEnumerable<BarangaysDTO>>> GetBarangaysByMunicipalityCode(string municipalityCode)
            => Ok(await _locationService.GetBarangaysByMunicipalityCodeAsync(municipalityCode));
    }
}

