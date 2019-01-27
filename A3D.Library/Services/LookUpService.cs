using A3D.Library.Models;
using A3D.Library.Models.LookUp;
using A3D.Library.Repositories.EntityFramework;
using A3D.Library.Repositories.LookUp;
using A3D.Library.Services.Interfaces;
using System.Collections.Generic;

namespace A3D.Library.Services
{
    public class LookUpService : ILookUpService
    {
        private readonly ILookUpRepository<ActivityPrivacy> activityPrivacyRepository;
        private readonly ILookUpRepository<ActivityStatus> activityStatusRepository;
        private readonly ILookUpRepository<NotificationType> notificationTypeRepository;

        public LookUpService(ILookUpRepository<ActivityPrivacy> activityPrivacyRepository,
            ILookUpRepository<ActivityStatus> activityStatusRepository,
            ILookUpRepository<NotificationType> notificationTypeRepository)
        {
            this.activityPrivacyRepository = activityPrivacyRepository;
            this.activityStatusRepository = activityStatusRepository;
            this.notificationTypeRepository = notificationTypeRepository;
        }

        public IDictionary<string, IEnumerable<BaseLookUpModel>> GetAll()
        {
            return new Dictionary<string, IEnumerable<BaseLookUpModel>>
            {
                { "ActivityPrivacy", this.activityPrivacyRepository.GetAll() },
                { "ActivityStatus", this.activityStatusRepository.GetAll() },
                { "NotificationType",  this.notificationTypeRepository.GetAll() }
            };
        }
    }
}
