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
            return this.activityService.GetByCreatorId(userId).ToList();
        }

        // GET rest/users/{userId}/activities/5
        [HttpGet("{id}")]
        public ActionResult<Activity> Get(int userId, int id)
        {
            // TODO add logic to check if userId has permission

            return this.activityService.GetById(id);
        }

        // POST rest/users/{userId}/activities
        [HttpPost]
        public void Post(int userId, [FromBody] Activity value)
        {
        }

        // PUT rest/users/{userId}/activities/5
        [HttpPut("{id}")]
        public void Put(int userId, int id, [FromBody] Activity value)
        {
        }

        // DELETE rest/users/{userId}/activities/5
        [HttpDelete("{id}")]
        public void Delete(int userId, int id)
        {
            // TODO add logic to check if userId has permission

            this.activityService.DeleteById(id);
        }
    }
}