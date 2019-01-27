using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class ActivityService : IActivityService
    {
        public int Create(Activity obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Activity GetById(int id)
        {
            return new Activity() { Id = id, Name = $"activity{id}" };
        }

        public IEnumerable<Activity> GetByCreatorId(int creatorId)
        {
            IList<Activity> list = new List<Activity>();
            list.Add(new Activity() { Id = 1, Name = "activity1", CreatorId = creatorId });
            list.Add(new Activity() { Id = 2, Name = "activity2", CreatorId = creatorId });
            list.Add(new Activity() { Id = 3, Name = "activity3", CreatorId = creatorId });

            return list;
        }

        public void Update(Activity obj)
        {
            throw new NotImplementedException();
        }
    }
}
