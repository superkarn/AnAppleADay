using A3D.Library.Global;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace A3D.Authentication.Controllers
{
    [Route("[controller]")]
    public class RedirectController : Controller
    {
        public IActionResult Index(string url, string application)
        {
            if (string.IsNullOrWhiteSpace(url) == false
                && string.IsNullOrWhiteSpace(application) == false)
            {
                var app = Application.Values.Where(x => x.Name.ToLower() == application.ToLower()).FirstOrDefault();

                if (app != null)
                {
                    return Redirect($"{app.BaseUrl}{url}");
                }

                return NotFound($"Unable to redirect to {url}.");
            }
            else
            {
                return NotFound($"Unable to redirect to {url}");
            }
        }
    }
}