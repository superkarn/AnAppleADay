using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using A3D.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security;
using System.Security.Claims;

namespace A3D.Web.Areas.Activities.Pages.Details
{
    [Authorize]
    public class IndexModel : BasePageModel
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
            // If the parameter is int, load the object by Id
            if (int.TryParse(activityId, out int activityIdInt))
            {
                try
                {
                    this.Activity = this.activityService.GetById(this.context, activityIdInt);
                }
                // If there's a SecurityException, return 404
                // We don't want to return 401 or 403 because it would expose internal metadata.
                catch (SecurityException)
                {
                    return NotFound();
                }
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

            // If Activity is null by this point, return 404
            if (this.Activity == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(Activity model)
        {
            model.LastModifiedDate = DateTime.UtcNow;

            // If the model id is 0, assume we're creating a new object
            if (model.Id == 0)
            {
                // This is how you get the current user's Id
                // https://stackoverflow.com/a/52135130/1398750
                model.CreatorId = this.context.CurrentUser.Id;

                this.activityService.Create(this.context, model);
            }
            // Else update the object matching this Id
            else
            {
                this.activityService.Update(this.context, model);
            }

            return Redirect($"~/u/{User.Identity.Name}/Activities/{model.Id}");
        }

        public IActionResult OnPostDelete(int id)
        {
            this.activityService.DeleteById(this.context, id);

            return Redirect($"~/u/{User.Identity.Name}/Activities");
        }
    }
}