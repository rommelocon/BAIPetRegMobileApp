using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("[controller]")]
    public class CivilStatusController(UserDbContext userDbContext) : BaseController<TblCivilStatus>(userDbContext)
    {
    }
}
