using System.Collections.Generic;
using System.Linq;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Route("rest/users/{userId}/activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivitiesController(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        // GET rest/users/{userId}/activities
        [HttpGet]
        public ActionResult<IEnumerable<Activity>> Get(int userId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            return this.activityService.GetByCreatorId(context, userId).ToList();
        }

        // GET rest/users/{userId}/activities/5
        [HttpGet("{id}")]
        public ActionResult<Activity> Get(int userId, int id)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            return this.activityService.GetById(context, id);
        }

        // POST rest/users/{userId}/activities
        [HttpPost]
        public ActionResult<int> Post(int userId, [FromBody] Activity value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            try
            {
                return this.activityService.Create(context, value);
            }
            catch
            {
                // for now, return 409 Conflict
                return Conflict();
            }
        }

        // PUT rest/users/{userId}/activities/5
        [HttpPut("{id}")]
        public void Put(int userId, int id, [FromBody] Activity value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            this.activityService.Update(context, value);
        }

        // DELETE rest/users/{userId}/activities/5
        [HttpDelete("{id}")]
        public void Delete(int userId, int id)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            this.activityService.DeleteById(context, id);
        }
    }
}