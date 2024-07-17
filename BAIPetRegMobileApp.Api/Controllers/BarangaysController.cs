using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("[controller]")]
    public class BarangaysController(UserDbContext userDbContext) : BaseController<TblBarangays>(userDbContext)
    {
    }
}
