using A3D.Library.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace A3D.Web.Utils
{
    public class BasePageModel : PageModel
    {
        public ApplicationContext context;

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            base.OnPageHandlerExecuting(context);

            this.context = new ApplicationContext()
            {
                CurrentUser = new ApplicationUser()
                {
                    Id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    UserName = this.User.Identity.Name
                }
            };
        }
    }
}
