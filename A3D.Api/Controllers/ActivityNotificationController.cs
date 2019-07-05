using System.Collections.Generic;
using System.Linq;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Authorize]
    [Route("api/users/{username}/activities/{activityId}/notifications")]
    [ApiController]
    public class ActivityNotificationController : ControllerBase
    {
        private readonly IActivityNotificationService  activityNotificationService;

        public ActivityNotificationController(IActivityNotificationService activityNotificationService)
        {
            this.activityNotificationService = activityNotificationService;
        }

        // GET api/users/{username}/activities/{activityId}/notifications
        [HttpGet]
        public ActionResult<IEnumerable<ActivityNotification>> Get(string username, int activityId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            return this.activityNotificationService.GetByActivityId(context, activityId).ToList();
        }

        // GET api/users/{username}/activities/{activityId}/notifications/notificationTypes/5
        [HttpGet("notificationTypes/{notificationTypeId}")]
        public ActionResult<ActivityNotification> Get(string username, int activityId, int notificationTypeId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            return this.activityNotificationService.GetByKey(context, activityId, notificationTypeId);
        }

        // POST api/users/{username}/activities/{activityId}/notifications
        [HttpPost]
        public ActionResult Post(string username, int activityId, [FromBody] ActivityNotification value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            try
            {
                this.activityNotificationService.Create(context, value);
                return Ok();
            }
            catch
            {
                // for now, return 409 Conflict
                return Conflict();
            }
        }

        // PUT api/users/{username}/activities/{activityId}/notifications/notificationTypes/5
        [HttpPut("notificationTypes/{notificationTypeId}")]
        public void Put(string username, int activityId, int notificationTypeId, [FromBody] ActivityNotification value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            this.activityNotificationService.Update(context, value);
        }

        // DELETE api/users/{username}/activities/{activityId}/notifications/notificationTypes/5
        [HttpDelete("notificationTypes/{notificationTypeId}")]
        public void Delete(string username, int activityId, int notificationTypeId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            this.activityNotificationService.DeleteByKey(context, activityId, notificationTypeId);
        }
    }
}