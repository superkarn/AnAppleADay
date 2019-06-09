using A3D.Library.Models;
using A3D.Library.Models.LookUp;
using A3D.Library.Services.Interfaces;
using System.Collections.Generic;

namespace A3D.Library.Services.LookUp
{
    public class LookUpService : ILookUpService
    {
        public LookUpService()
        { }

        public IDictionary<string, IEnumerable<BaseLookUpModel>> GetAll(ApplicationContext context)
        {
            return new Dictionary<string, IEnumerable<BaseLookUpModel>>
            {
                { "ActivityPrivacies", ActivityPrivacy.GetValues() },
                { "ActivityInstanceStatuses", ActivityInstanceStatus.GetValues() },
                { "NotificationTypes",  NotificationType.GetValues() }
            };
        }
    }
}
