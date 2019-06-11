using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;

namespace A3D.Web.Areas.Activities.Pages.Details
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IActivityService activityService;
        private const string ADD_URL = "add";

        public Activity Activity;

        public IndexModel(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        public IActionResult OnGet(string activityId)
        {
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = this.User.ToString() } };

            // If the parameter is int, load the object by Id
            if (int.TryParse(activityId, out int activityIdInt))
            {
                this.Activity = this.activityService.GetById(context, activityIdInt);
            }
            // If the parameter matches the ADD_URL, load a new object
            else if (activityId.Equals(ADD_URL, StringComparison.InvariantCultureIgnoreCase))
            {
                this.Activity = new Activity();
            }
            // Else return 404
            else
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(Activity model)
        {
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = this.User.ToString() } };

            model.LastModifiedDate = DateTime.UtcNow;

            // If the model id is 0, assume we're creating a new object
            if (model.Id == 0)
            {
                // This is how you get the current user's Id
                // https://stackoverflow.com/a/52135130/1398750
                model.CreatorId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

                this.activityService.Create(context, model);
            }
            // Else update the object matching this Id
            else
            {
                this.activityService.Update(context, model);
            }

            return Redirect($"~/u/{User.Identity.Name}/Activities/{model.Id}");
        }

        public IActionResult OnPostDelete(int id)
        {
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = this.User.ToString() } };

            this.activityService.DeleteById(context, id);

            return Redirect($"~/u/{User.Identity.Name}/Activities");
        }
    }
}