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
            return this.activityInstanceService.GetByActivityId(activityId).ToList();
        }

        // GET rest/users/{userId}/activities/{activityId}/instances/5
        [HttpGet("{id}")]
        public ActionResult<ActivityInstance> Get(int userId, int activityId, int id)
        {
            // TODO add logic to check if userId has access to this Activity

            return this.activityInstanceService.GetById(id);
        }

        // POST rest/users/{userId}/activities/{activityId}/instances
        [HttpPost]
        public ActionResult<int> Post(int userId, int activityId, [FromBody] ActivityInstance value)
        {
            try
            {
                return this.activityInstanceService.Create(value);
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
            this.activityInstanceService.Update(value);
        }

        // DELETE rest/users/{userId}/activities/{activityId}/instances/5
        [HttpDelete("{id}")]
        public void Delete(int userId, int activityId, int id)
        {
            this.activityInstanceService.DeleteById(id);
        }
    }
}