using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Authorize]
    [Route("api/users/{username}/activities/{activityId}/notifications")]
    [ApiController]
    public class ActivityNotificationController : BaseController
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
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.activityNotificationService.GetByActivityId(this.Context, activityId).ToList();
        }

        // GET api/users/{username}/activities/{activityId}/notifications/notificationTypes/5
        [HttpGet("notificationTypes/{notificationTypeId}")]
        public ActionResult<ActivityNotification> Get(string username, int activityId, int notificationTypeId)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.activityNotificationService.GetByKey(this.Context, activityId, notificationTypeId);
        }

        // POST api/users/{username}/activities/{activityId}/notifications
        [HttpPost]
        public ActionResult Post(string username, int activityId, [FromBody] ActivityNotification value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.activityNotificationService.Create(this.Context, value);
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
        public ActionResult Put(string username, int activityId, int notificationTypeId, [FromBody] ActivityNotification value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.activityNotificationService.Update(this.Context, value);
            }
            catch (Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }

            return Ok();
        }

        // DELETE api/users/{username}/activities/{activityId}/notifications/notificationTypes/5
        [HttpDelete("notificationTypes/{notificationTypeId}")]
        public ActionResult Delete(string username, int activityId, int notificationTypeId)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.activityNotificationService.DeleteByKey(this.Context, activityId, notificationTypeId);
            }
            catch (Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }

            return Ok();
        }
    }
}