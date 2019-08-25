using System.Collections.Generic;
using System.Security.Claims;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpValuesController : BaseController
    {
        private readonly ILookUpService lookUpService;

        public LookUpValuesController(ILookUpService lookUpService)
        {
            this.lookUpService = lookUpService;
        }

        // GET api/lookUpValues
        [HttpGet]
        public ActionResult<IDictionary<string, IEnumerable<BaseLookUpModel>>> Get()
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return new ActionResult<IDictionary<string, IEnumerable<BaseLookUpModel>>>(this.lookUpService.GetAll(this.Context));
        }
    }
}