using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : BaseController<TblRegions, UserDbContext, string>
    {
        public RegionsController(UserDbContext context) : base(context) { }

        protected override string GetId(TblRegions entity) => entity.Rcode;

        protected override bool IdMatches(TblRegions entity, string id) => entity.Rcode == id;
    }
}