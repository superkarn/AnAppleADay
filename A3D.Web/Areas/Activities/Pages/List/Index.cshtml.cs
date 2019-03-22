using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace A3D.Web.Areas.Activities.Pages.List
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IActivityService activityService;

        public IEnumerable<Activity> Activities;

        public IndexModel(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        public void OnGet(string username)
        {
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = this.User.ToString() } };

            this.Activities = this.activityService.GetByCreatorUsername(context, username);
        }
    }
}