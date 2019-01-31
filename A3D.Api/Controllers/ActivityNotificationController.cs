using System.Collections.Generic;
using System.Linq;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
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
            return this.activityNotificationService.GetByActivityId(activityId).ToList();
        }

        // GET rest/users/{userId}/activities/{activityId}/notifications/notificationTypes/5
        [HttpGet("notificationTypes/{notificationTypeId}")]
        public ActionResult<ActivityNotification> Get(int userId, int activityId, int notificationTypeId)
        {
            return this.activityNotificationService.GetByKey(activityId, notificationTypeId);
        }

        // POST rest/users/{userId}/activities/{activityId}/notifications
        [HttpPost]
        public ActionResult Post(int userId, int activityId, [FromBody] ActivityNotification value)
        {
            try
            {
                this.activityNotificationService.Create(value);
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
            this.activityNotificationService.Update(value);
        }

        // DELETE rest/users/{userId}/activities/{activityId}/notifications/notificationTypes/5
        [HttpDelete("notificationTypes/{notificationTypeId}")]
        public void Delete(int userId, int activityId, int notificationTypeId)
        {
            this.activityNotificationService.DeleteByKey(activityId, notificationTypeId);
        }
    }
}