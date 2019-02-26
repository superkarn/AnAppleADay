using A3D.Library.Global;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A3D.Web.Pages.Activities
{
    [Authorize(AuthenticationSchemes = AuthenticationConfigs.AUTHENTICATION_SCHEME)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}