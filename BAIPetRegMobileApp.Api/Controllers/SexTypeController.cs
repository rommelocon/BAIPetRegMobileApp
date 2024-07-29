﻿using BAIPetRegMobileApp.Api.Data;
using BAIPetRegMobileApp.Api.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexTypeController : BaseController<SexType, UserDbContext, int>
    {
        public SexTypeController(UserDbContext context) : base(context) { }

        protected override int GetId(SexType entity) => entity.SexID;

        protected override bool IdMatches(SexType entity, int id) => entity.SexID == id;
    }
}
