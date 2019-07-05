using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtService authenticationService;

        public JwtController(IJwtService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        // POST api/jwt/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]JwtUser userObj)
        {
            var user = this.authenticationService.Authenticate(userObj.Username, userObj.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }

        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return "success";
        }
    }
}
