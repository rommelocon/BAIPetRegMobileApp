using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.PetRegistration;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalFemaleClassificationController : BaseController<AnimalFemaleClassification, PetRegistrationDbContext, int>
    {
        public AnimalFemaleClassificationController(PetRegistrationDbContext context) : base(context) { }

        protected override int GetId(AnimalFemaleClassification entity) => entity.AnimalFemaleClassID!;

        protected override bool IdMatches(AnimalFemaleClassification entity, int id) => entity.AnimalFemaleClassID == id;
    }
}
