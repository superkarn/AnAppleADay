using Microsoft.EntityFrameworkCore;
using System.Linq;
using A3D.Library.Data.Data;
using A3D.Library.Models;
using A3D.Library.Data.Repositories.Interfaces;

namespace A3D.Library.Data.Repositories.EntityFramework
{
    public class ActivityRepository : BaseWithIdRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context)
            : base(context)
        { }

        public override Activity GetById(int id)
        {
            return this.DbSet
                .Include(x => x.ActivityNotifications)
                .Include(x => x.Privacy)
                .SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Activity> GetByCreatorId(string creatorId)
        {
            return this.DbSet
                .Include(x => x.ActivityNotifications)
                .Include(x => x.Privacy)
                .Where(x => x.CreatorId == creatorId);
        }
    }
}
