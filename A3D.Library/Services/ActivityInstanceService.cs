using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class ActivityInstanceService : IActivityInstanceService
    {
        public int Create(ActivityInstance obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ActivityInstance GetById(int id)
        {
            return new ActivityInstance() { Id = id, ActivityId = 1000 + id, Value = $"value-{id}" };
        }

        public IEnumerable<ActivityInstance> GetByActivityId(int activityId)
        {
            IList<ActivityInstance> list = new List<ActivityInstance>();
            list.Add(new ActivityInstance() { Id = 1, ActivityId = activityId, Value = "value1", CreatorId = 11 });
            list.Add(new ActivityInstance() { Id = 2, ActivityId = activityId, Value = "value2", CreatorId = 22 });
            list.Add(new ActivityInstance() { Id = 3, ActivityId = activityId, Value = "value3", CreatorId = 33 });

            return list;
        }

        public void Update(ActivityInstance obj)
        {
            throw new NotImplementedException();
        }
    }
}
