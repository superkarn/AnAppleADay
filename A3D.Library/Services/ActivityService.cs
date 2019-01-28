using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;
using A3D.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public int Create(Activity obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            try
            {
                this.activityRepository.DeleteById(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // This exception is expected when trying to delete an item that does not exist.
                // We catch it and let it through, because the end result is as intially requested: the item no longer exists.
                // For any other exception, we let it bubble up.
                if (!ex.Message.Contains("Database operation expected to affect 1 row(s) but actually affected 0 row(s)"))
                {
                    throw ex;
                }
            }
        }

        public Activity GetById(int id)
        {
            return this.activityRepository.GetById(id);
        }

        public IEnumerable<Activity> GetByCreatorId(int creatorId)
        {
            return this.activityRepository.GetByCreatorId(creatorId);
        }

        public void Update(Activity obj)
        {
            throw new NotImplementedException();
        }
    }
}
