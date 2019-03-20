using System.Linq;
using A3D.Library.Data.Repositories.Interfaces;
using A3D.Library.Data.Data;
using A3D.Library.Models;

namespace A3D.Library.Data.Repositories.EntityFramework
{
    public class ActivityInstanceRepository : BaseWithIdRepository<ActivityInstance>, IActivityInstanceRepository
    {
        public ActivityInstanceRepository(ApplicationDbContext context)
            : base(context)
        { }

        public IQueryable<ActivityInstance> GetByActivityId(int activityId)
        {
            return this.DbSet.Where(x => x.ActivityId == activityId);
        }
    }
}
