using System.Collections.Generic;
using System.Linq;
using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace A3D.Api.Controllers
{
    [Route("rest/users/{userId}/activities/{activityId}/instances")]
    [ApiController]
    public class ActivityInstanceController : ControllerBase
    {
        private readonly IActivityInstanceService activityInstanceService;

        public ActivityInstanceController(IActivityInstanceService activityInstanceService)
        {
            this.activityInstanceService = activityInstanceService;
        }

        // GET rest/users/{userId}/activities/{activityId}/instances
        [HttpGet]
        public ActionResult<IEnumerable<ActivityInstance>> Get(int userId, int activityId)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            return this.activityInstanceService.GetByActivityId(context, activityId).ToList();
        }

        // GET rest/users/{userId}/activities/{activityId}/instances/5
        [HttpGet("{id}")]
        public ActionResult<ActivityInstance> Get(int userId, int activityId, int id)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            return this.activityInstanceService.GetById(context, id);
        }

        // POST rest/users/{userId}/activities/{activityId}/instances
        [HttpPost]
        public ActionResult<int> Post(int userId, int activityId, [FromBody] ActivityInstance value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            try
            {
                return this.activityInstanceService.Create(context, value);
            }
            catch
            {
                // for now, return 409 Conflict
                return Conflict();
            }
        }

        // PUT rest/users/{userId}/activities/{activityId}/instances/5
        [HttpPut("{id}")]
        public void Put(int userId, int activityId, int id, [FromBody] ActivityInstance value)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            this.activityInstanceService.Update(context, value);
        }

        // DELETE rest/users/{userId}/activities/{activityId}/instances/5
        [HttpDelete("{id}")]
        public void Delete(int userId, int activityId, int id)
        {
            // TODO replace this with the current user
            var context = new ApplicationContext() { CurrentUser = new ApplicationUser() { Id = userId } };

            this.activityInstanceService.DeleteById(context, id);
        }
    }
}