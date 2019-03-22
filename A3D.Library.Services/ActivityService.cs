using A3D.Library.Models;
using A3D.Library.Data.Repositories.Interfaces;
using A3D.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace A3D.Library.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;
        private readonly IApplicationUserRepository identityUserRepository;

        public ActivityService(IActivityRepository activityRepository, IApplicationUserRepository identityUserRepository)
        {
            this.activityRepository = activityRepository;
            this.identityUserRepository = identityUserRepository;
        }

        public int Create(ApplicationContext context, Activity item)
        {
            return this.activityRepository.Create(item);
        }

        public void DeleteById(ApplicationContext context, int id)
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

        public Activity GetById(ApplicationContext context, int id)
        {
            return this.activityRepository.GetById(id);
        }

        public IEnumerable<Activity> GetByCreatorId(ApplicationContext context, string creatorId)
        {
            return this.activityRepository.GetByCreatorId(creatorId);
        }

        public IEnumerable<Activity> GetByCreatorUsername(ApplicationContext context, string username)
        {
            var user = this.identityUserRepository.GetByUsername(username).FirstOrDefault();

            return this.activityRepository.GetByCreatorId(user.Id);
        }

        public void Update(ApplicationContext context, Activity item)
        {
            var existingItem = this.activityRepository.GetById(item.Id);

            // TODO make this work with PATCH
            existingItem.Name = item.Name;
            existingItem.Privacy = item.Privacy;
            existingItem.Description = item.Description;
            existingItem.ValueUnit = item.ValueUnit;
            existingItem.Schedule = item.Schedule;
            existingItem.LastModifiedDate = DateTime.UtcNow;
            existingItem.LastCompletedDate = item.LastCompletedDate;

            this.activityRepository.Update(item);
        }
    }
}
