using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using A3D.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace A3D.Web.Areas.Activities.Pages.History
{
    [Authorize]
    public class IndexModel : BasePageModel
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
            this.Activity = this.activityService.GetById(this.context, activityId);
            this.ActivityInstances = this.activityInstanceService.GetByActivityId(this.context, activityId);
        }
    }
}