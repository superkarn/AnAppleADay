using System.Collections.Generic;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Route("rest/lookUpValues")]
    [ApiController]
    public class LookUpValuesController : ControllerBase
    {
        private readonly ILookUpService lookUpService;

        public LookUpValuesController(ILookUpService lookUpService)
        {
            this.lookUpService = lookUpService;
        }

        // GET rest/lookUpValues
        [HttpGet]
        public ActionResult<IDictionary<string, IEnumerable<BaseLookUpModel>>> Get()
        {
            return new ActionResult<IDictionary<string, IEnumerable<BaseLookUpModel>>>(this.lookUpService.GetAll());
        }
    }
}