using A3D.Library.Models;
using A3D.Library.Models.LookUp;
using A3D.Library.Data.Repositories.Interfaces;
using A3D.Library.Services.Interfaces;
using System.Collections.Generic;

namespace A3D.Library.Services.LookUp
{
    public class LookUpService : ILookUpService
    {
        private readonly ILookUpRepository<ActivityPrivacy> activityPrivacyRepository;
        private readonly ILookUpRepository<ActivityInstanceStatus> activityStatusRepository;
        private readonly ILookUpRepository<NotificationType> notificationTypeRepository;

        public LookUpService(ILookUpRepository<ActivityPrivacy> activityPrivacyRepository,
            ILookUpRepository<ActivityInstanceStatus> activityStatusRepository,
            ILookUpRepository<NotificationType> notificationTypeRepository)
        {
            this.activityPrivacyRepository = activityPrivacyRepository;
            this.activityStatusRepository = activityStatusRepository;
            this.notificationTypeRepository = notificationTypeRepository;
        }

        public IDictionary<string, IEnumerable<BaseLookUpModel>> GetAll(ApplicationContext context)
        {
            return new Dictionary<string, IEnumerable<BaseLookUpModel>>
            {
                { "ActivityPrivacies", this.activityPrivacyRepository.GetAll() },
                { "ActivityStatuses", this.activityStatusRepository.GetAll() },
                { "NotificationTypes",  this.notificationTypeRepository.GetAll() }
            };
        }
    }
}
