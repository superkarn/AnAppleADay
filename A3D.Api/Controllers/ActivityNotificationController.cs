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

        // GET rest/users/{userId}/activities/{activityId}/notifications/5
        [HttpGet("{id}")]
        public ActionResult<ActivityNotification> Get(int userId, int activityId, int id)
        {
            // TODO add logic to check if userId has access to this Activity

            return this.activityNotificationService.GetById(id);
        }

        // POST rest/users/{userId}/activities/{activityId}/notifications
        [HttpPost]
        public void Post(int userId, int activityId, [FromBody] Activity value)
        {
        }

        // PUT rest/users/{userId}/activities/{activityId}/notifications/5
        [HttpPut("{id}")]
        public void Put(int userId, int activityId, int id, [FromBody] Activity value)
        {
        }

        // DELETE rest/users/{userId}/activities/{activityId}/notifications/5
        [HttpDelete("{id}")]
        public void Delete(int userId, int activityId, int id)
        {
        }
    }
}