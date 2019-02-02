using System.Collections.Generic;
using System.Linq;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Authorize]
    [Route("rest/users/{userId}/activities/{activityId}/notifications")]
    [ApiController]
    public class ActivityNotificationController : ControllerBase
    {
        private readonly IActivityNotificationService  activityNotificationService;

        public ActivityNotificationController(IActivityNotificationService activityNotificationService)
        {
            this.activityNotificationService = activityNotificationService;
        }

        // GET rest/users/{userId}/activities/{activityId}/notifications
        [HttpGet]
        public ActionResult<IEnumerable<ActivityNotification>> Get(int userId, int activityId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            return this.activityNotificationService.GetByActivityId(context, activityId).ToList();
        }

        // GET rest/users/{userId}/activities/{activityId}/notifications/notificationTypes/5
        [HttpGet("notificationTypes/{notificationTypeId}")]
        public ActionResult<ActivityNotification> Get(int userId, int activityId, int notificationTypeId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            return this.activityNotificationService.GetByKey(context, activityId, notificationTypeId);
        }

        // POST rest/users/{userId}/activities/{activityId}/notifications
        [HttpPost]
        public ActionResult Post(int userId, int activityId, [FromBody] ActivityNotification value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

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

        // PUT rest/users/{userId}/activities/{activityId}/notifications/notificationTypes/5
        [HttpPut("notificationTypes/{notificationTypeId}")]
        public void Put(int userId, int activityId, int notificationTypeId, [FromBody] ActivityNotification value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            this.activityNotificationService.Update(context, value);
        }

        // DELETE rest/users/{userId}/activities/{activityId}/notifications/notificationTypes/5
        [HttpDelete("notificationTypes/{notificationTypeId}")]
        public void Delete(int userId, int activityId, int notificationTypeId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            this.activityNotificationService.DeleteByKey(context, activityId, notificationTypeId);
        }
    }
}