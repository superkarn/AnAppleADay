using A3D.Library.Models.LookUp;
using A3D.Library.Repositories.EntityFramework;

namespace A3D.Library.Repositories.LookUp
{
    public class ActivityStatusRepository : BaseLookUpRepository<ActivityStatus>
    {
        public ActivityStatusRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
