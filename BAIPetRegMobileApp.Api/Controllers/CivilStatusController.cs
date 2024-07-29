using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilStatusController : BaseController<CivilStatuses, UserDbContext, int>
    {
        public CivilStatusController(UserDbContext context) : base(context) { }

        protected override int GetId(CivilStatuses entity) => entity.CivilCode;

        protected override bool IdMatches(CivilStatuses entity, int id) => entity.CivilCode == id;
    }
}
