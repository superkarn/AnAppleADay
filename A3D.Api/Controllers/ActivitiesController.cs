using System;
using System.Collections.Generic;
using System.Linq;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Authorize]
    [Route("api/users/{username}/activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivitiesController(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        // GET api/users/{username}/activities
        [HttpGet]
        public ActionResult<IEnumerable<Activity>> Get(string username)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            return this.activityService.GetByCreatorUsername(context, username).ToList();
        }

        // GET api/users/{username}/activities/5
        [HttpGet("{id}")]
        public ActionResult<Activity> Get(string username, int id)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            return this.activityService.GetById(context, id);
        }

        // POST api/users/{username}/activities
        [HttpPost]
        public ActionResult Post(string username, [FromBody] Activity value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            try
            {
                var newId = this.activityService.Create(context, value);
                return Created($"api/users/{username}/activites/{newId}", newId);
            }
            catch(Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }
        }

        // PUT api/users/{username}/activities/5
        [HttpPut("{id}")]
        public ActionResult Put(string username, int id, [FromBody] Activity value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            try
            {
                this.activityService.Update(context, value);
            }
            catch (Exception ex)
            {
                // TODO convert this into user-friendly response
                // for now, return 409 Conflict
                return Conflict(ex);
            }

            return Ok();
        }

        // DELETE api/users/{username}/activities/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string username, int id)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { UserName = username } };

            try
            {
                this.activityService.DeleteById(context, id);
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