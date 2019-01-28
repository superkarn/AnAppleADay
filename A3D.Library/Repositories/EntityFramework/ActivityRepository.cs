using System.Linq;
using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;

namespace A3D.Library.Repositories.EntityFramework
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public override void DeleteById(int id)
        {
            Activity item = new Activity() { Id = id };
            this.Context.Activities.Attach(item);
            this.Context.Activities.Remove(item);
            this.Context.SaveChanges();
        }

        public IQueryable<Activity> GetByCreatorId(int creatorId)
        {
            return this.DbSet.Where(x => x.CreatorId == creatorId);
        }
    }
}
