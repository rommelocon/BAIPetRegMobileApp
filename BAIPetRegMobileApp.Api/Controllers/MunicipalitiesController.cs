using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("[controller]")]
    public class MunicipalitiesController(UserDbContext userDbContext) : BaseController<TblMunicipalities>(userDbContext)
    {
    }
}