using A3D.Authentication.Models;
using A3D.Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Authentication.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtService authenticationService;

        public JwtController(IJwtService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userObj)
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
