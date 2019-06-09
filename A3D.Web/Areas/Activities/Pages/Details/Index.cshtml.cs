using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

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

        public IActionResult OnPost(Activity model)
        {
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = this.User.ToString() } };

            model.LastModifiedDate = DateTime.UtcNow;

            this.activityService.Update(context, model);

            return Redirect($"~/u/{User.Identity.Name}/Activities/{model.Id}");
        }
    }
}