using System.Linq;
using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;

namespace A3D.Library.Repositories.EntityFramework
{
    public class ActivityInstanceRepository : BaseWithIdRepository<ActivityInstance>, IActivityInstanceRepository
    {
        public ActivityInstanceRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<ActivityInstance> GetByActivityId(int activityId)
        {
            return this.DbSet.Where(x => x.ActivityId == activityId);
        }
    }
}
