using System.Linq;
using A3D.Library.Data.Data;
using A3D.Library.Models;
using A3D.Library.Data.Repositories.Interfaces;
using A3D.Library.Data.Repositories.EntityFramework;

namespace A3D.Library.Repositories.EntityFramework
{
    public class ActivityRepository : BaseWithIdRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context)
            : base(context)
        { }

        public IQueryable<Activity> GetByCreatorId(string creatorId)
        {
            return this.DbSet.Where(x => x.CreatorId == creatorId);
        }
    }
}
