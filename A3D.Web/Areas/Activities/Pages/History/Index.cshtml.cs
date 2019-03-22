using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace A3D.Web.Areas.Activities.Pages.History
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IActivityService activityService;
        private readonly IActivityInstanceService activityInstanceService;

        public Activity Activity;
        public IEnumerable<ActivityInstance> ActivityInstances;

        public IndexModel(IActivityService activityService, IActivityInstanceService activityInstanceService)
        {
            this.activityService = activityService;
            this.activityInstanceService = activityInstanceService;
        }

        public void OnGet(int activityId)
        {
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = this.User.ToString() } };

            this.Activity = this.activityService.GetById(context, activityId);
            this.ActivityInstances = this.activityInstanceService.GetByActivityId(context, activityId);
        }
    }
}