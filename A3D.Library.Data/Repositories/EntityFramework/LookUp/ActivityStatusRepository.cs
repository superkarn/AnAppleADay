using A3D.Library.Data.Data;
using A3D.Library.Models.LookUp;

namespace A3D.Library.Data.Repositories.EntityFramework.LookUp
{
    public class ActivityStatusRepository : BaseLookUpRepository<ActivityInstanceStatus>
    {
        public ActivityStatusRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
