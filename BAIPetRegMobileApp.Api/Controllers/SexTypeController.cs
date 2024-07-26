using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexTypeController : BaseController<TblSexType, UserDbContext, int>
    {
        public SexTypeController(UserDbContext context) : base(context) { }

        protected override int GetId(TblSexType entity) => entity.SexID;

        protected override bool IdMatches(TblSexType entity, int id) => entity.SexID == id;
    }
}
