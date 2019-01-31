using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;
using A3D.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class ActivityInstanceService : IActivityInstanceService
    {
        private readonly IActivityInstanceRepository activityInstanceRepository;

        public ActivityInstanceService(IActivityInstanceRepository activityInstanceRepository)
        {
            this.activityInstanceRepository = activityInstanceRepository;
        }

        public int Create(ActivityInstance item)
        {
            return this.activityInstanceRepository.Create(item);
        }

        public void DeleteById(int id)
        {
            try
            {
                this.activityInstanceRepository.DeleteById(id);
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

        public ActivityInstance GetById(int id)
        {
            return this.activityInstanceRepository.GetById(id);
        }

        public IEnumerable<ActivityInstance> GetByActivityId(int activityId)
        {
            return this.activityInstanceRepository.GetByActivityId(activityId);
        }

        public void Update(ActivityInstance item)
        {
            var existingItem = this.activityInstanceRepository.GetById(item.Id);

            // TODO make this work with PATCH
            existingItem.StatusId = item.StatusId;
            existingItem.Value = item.Value;
            existingItem.Notes = item.Notes;
            existingItem.LastModifiedDate = DateTime.UtcNow;

            this.activityInstanceRepository.Update(item);
        }
    }
}
