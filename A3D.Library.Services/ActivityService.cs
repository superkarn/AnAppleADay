using A3D.Library.Models;
using A3D.Library.Data.Repositories.Interfaces;
using A3D.Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security;
using A3D.Library.Models.LookUp;

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

        /// <summary>
        /// Delete an Activity by id.
        /// 
        /// PERMISSIONS
        ///   Only allow Activity creator to delete it.
        ///   TODO allow admin in the future?
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public void DeleteById(ApplicationContext context, int id)
        {
            // If there's no current user, don't allow
            if (context.CurrentUser == null)
            {
                throw new SecurityException($"User NULL is unauthorized to delete Activity id {id}");
            }

            var activity = this.activityRepository.GetById(id);
            
            // If the item doesn't exist, treat it as if the item has been deleted
            if (activity == null)
            {
                return;
            }

            // TODO allow Admin 
            // If the current user is not the item creator, don't allow
            if (activity.CreatorId != context.CurrentUser.Id)
            {
                throw new SecurityException($"User {context.CurrentUser.Id} is unauthorized to delete Activity id {id}");
            }
            
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

        /// <summary>
        /// Returns an Activity by id.
        /// 
        /// PERMISSIONS
        ///   Allow anybody to see all public Activities.
        ///   Only allow Activity creator to see private Activities.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Activity GetById(ApplicationContext context, int id)
        {
            var activity = this.activityRepository.GetById(id);

            if (activity != null)
            {
                if (activity.PrivacyId == ActivityPrivacy.Private.Id
                    && activity.CreatorId != context.CurrentUser.Id)
                {
                    throw new SecurityException($"User {context.CurrentUser.Id} is unauthorized to view Activity id {id}");
                }
            }

            return activity;
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
            // If there's no current user, don't allow
            if (context.CurrentUser == null)
            {
                throw new SecurityException($"User NULL is unauthorized to delete Activity id {item.Id}");
            }

            var existingItem = this.activityRepository.GetById(item.Id);
            
            // If the item doesn't exist, throw an exception
            if (existingItem == null)
            {
                throw new NullReferenceException($"Activity id {item.Id} does not exist.");
            }

            // TODO allow Admin 
            // If the current user is not the item creator, don't allow
            if (existingItem.CreatorId != context.CurrentUser.Id)
            {
                throw new SecurityException($"User {context.CurrentUser.Id} is unauthorized to update Activity id {item.Id}.");
            }

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
