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
    [Route("api/users/{username}/activities")]
    [ApiController]
    public class ActivitiesController : BaseController
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
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.activityService.GetByCreatorUsername(this.Context, username).ToList();
        }

        // GET api/users/{username}/activities/5
        [HttpGet("{id}")]
        public ActionResult<Activity> Get(string username, int id)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            return this.activityService.GetById(Context, id);
        }

        // POST api/users/{username}/activities
        [HttpPost]
        public ActionResult Post(string username, [FromBody] Activity value)
        {
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                var newId = this.activityService.Create(this.Context, value);
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
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.activityService.Update(this.Context, value);
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
            this.Context = this.CreateApplicationContext((ClaimsIdentity)HttpContext.User.Identity);

            try
            {
                this.activityService.DeleteById(this.Context, id);
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