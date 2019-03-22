using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A3D.Web.Areas.Activities.Pages.Details
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IActivityService activityService;

        public Activity Activity;

        public IndexModel(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        public void OnGet(int activityId)
        {
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = this.User.ToString() } };

            this.Activity = this.activityService.GetById(context, activityId);
        }
    }
}