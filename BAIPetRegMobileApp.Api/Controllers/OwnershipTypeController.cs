using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.PetRegistration;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnershipTypeController : BaseController<OwnerShipType, PetRegistrationDbContext, string>
    {
        public OwnershipTypeController(PetRegistrationDbContext context) : base(context) { }

        protected override string GetId(OwnerShipType entity) => entity.OwnerShipTypeID!;

        protected override bool IdMatches(OwnerShipType entity, string id) => entity.OwnerShipTypeID == id;
    }
}