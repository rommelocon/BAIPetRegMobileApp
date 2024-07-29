using Microsoft.AspNetCore.Mvc;
using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.PetRegistration;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : BaseController<Regions, UserDbContext, string>
    {
        public RegionsController(UserDbContext context) : base(context) { }

        protected override string GetId(Regions entity) => entity.Rcode!;

        protected override bool IdMatches(Regions entity, string id) => entity.Rcode == id;
    }
}