using A3D.Library.Models.LookUp;
using A3D.Library.Repositories.EntityFramework;

namespace A3D.Library.Repositories.LookUp
{
    public class ActivityPrivacyRepository : BaseLookUpRepository<ActivityPrivacy>
    {
        public ActivityPrivacyRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
