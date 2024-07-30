using BAIPetRegMobileApp.Api.Data.User;
using BAIPetRegMobileApp.Api.Interfaces;
using BAIPetRegMobileApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexTypeController : ControllerBase
    {
       private readonly ISexTypeService sexTypeService;

        public SexTypeController(ISexTypeService sexTypeService)
        {
            this.sexTypeService = sexTypeService;
        }

        [HttpGet("sex")]
        public async Task<ActionResult<IEnumerable<SexType>>> GetRegions()
        {
            var sexTypes = await sexTypeService.GetSexTypeAsync();
            return Ok(sexTypes);
        }
    }
}
