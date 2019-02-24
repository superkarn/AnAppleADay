using A3D.Library.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A3D.Web.Pages.Activities
{
    [Authorize(AuthenticationSchemes = ApplicationConfigurations.AUTHENTICATION_SCHEME)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}