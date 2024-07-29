using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.PetRegistration;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalColorController : BaseController<AnimalColor, PetRegistrationDbContext, string>
    {
        public AnimalColorController(PetRegistrationDbContext context) : base(context) { }

        protected override string GetId(AnimalColor entity) => entity.AnimalColorID!;

        protected override bool IdMatches(AnimalColor entity, string id) => entity.AnimalColorID == id;
    }
}
