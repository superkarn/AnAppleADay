using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using A3D.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace A3D.Web.Areas.Activities.Pages.List
{
    [Authorize]
    public class IndexModel : BasePageModel
    {
        private readonly IActivityService activityService;

        public IEnumerable<Activity> Activities;

        public IndexModel(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        public void OnGet(string username)
        {
            this.Activities = this.activityService.GetByCreatorUsername(this.context, username);
        }
    }
}