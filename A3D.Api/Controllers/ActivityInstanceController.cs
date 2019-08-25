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
    [Route("api/users/{username}/activities/{activityId}/instances")]
    [ApiController]
    public class ActivityInstanceController : BaseController
    {
        private readonly IActivityInstanceService activityInstanceService;

        public ActivityInstanceController(IActivityInstanceService activityInstanceService)
        {
            this.activityInstanceService = activityInstanceService;
        }

        // GET api/users/{username}/activities/{activityId}/instances
        [HttpGet]
        public ActionResult<IEnumerable<ActivityInstance>> Get(string username, int activityId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            return this.activityInstanceService.GetByActivityId(context, activityId).ToList();
        }

        // GET api/users/{username}/activities/{activityId}/instances/5
        [HttpGet("{id}")]
        public ActionResult<ActivityInstance> Get(string username, int activityId, int id)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            return this.activityInstanceService.GetById(context, id);
        }

        // POST api/users/{username}/activities/{activityId}/instances
        [HttpPost]
        public ActionResult<int> Post(string username, int activityId, [FromBody] ActivityInstance value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                var newId = this.activityInstanceService.Create(this.Context, value);
                return Created($"api/users/{username}/activites/instances/{newId}", newId);
            }
            catch (Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }
        }

        // PUT api/users/{username}/activities/{activityId}/instances/5
        [HttpPut("{id}")]
        public ActionResult Put(string username, int activityId, int id, [FromBody] ActivityInstance value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.activityInstanceService.Update(this.Context, value);
            }
            catch (Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }

            return Ok();
        }

        // DELETE api/users/{username}/activities/{activityId}/instances/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string username, int activityId, int id)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.activityInstanceService.DeleteById(this.Context, id);
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