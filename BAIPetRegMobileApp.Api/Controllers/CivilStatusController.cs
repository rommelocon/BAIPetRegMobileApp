using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilStatusController : BaseController<TblCivilStatus, UserDbContext, int>
    {
        public CivilStatusController(UserDbContext context) : base(context) { }

        protected override int GetId(TblCivilStatus entity) => entity.CivilCode;

        protected override bool IdMatches(TblCivilStatus entity, int id) => entity.CivilCode == id;
    }
}
