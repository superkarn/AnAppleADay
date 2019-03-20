using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Data.Repositories.Interfaces
{
    public interface IActivityInstanceRepository : ICrudRepository<ActivityInstance>
    {
        IQueryable<ActivityInstance> GetByActivityId(int activityId);
    }
}
