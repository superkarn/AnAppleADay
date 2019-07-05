using System.Collections.Generic;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    //[Authorize]
    [Route("api/LookUpValues")]
    [ApiController]
    public class LookUpValuesController : ControllerBase
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
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = "1" } };

            return new ActionResult<IDictionary<string, IEnumerable<BaseLookUpModel>>>(this.lookUpService.GetAll(context));
        }
    }
}