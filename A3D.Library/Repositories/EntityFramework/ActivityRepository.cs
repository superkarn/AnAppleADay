using System.Linq;
using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;

namespace A3D.Library.Repositories.EntityFramework
{
    public class ActivityRepository : BaseWithIdRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<Activity> GetByCreatorId(int creatorId)
        {
            return this.DbSet.Where(x => x.CreatorId == creatorId);
        }
    }
}
