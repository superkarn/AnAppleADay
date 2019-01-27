using A3D.Library.Models.LookUp;

namespace A3D.Library.Repositories.EntityFramework.LookUp
{
    public class ActivityStatusRepository : BaseLookUpRepository<ActivityStatus>
    {
        public ActivityStatusRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
