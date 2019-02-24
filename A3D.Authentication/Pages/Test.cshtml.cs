using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A3D.Authentication.Pages
{
    [Authorize]
    public class TestModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}