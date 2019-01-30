using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Repositories.Interfaces
{
    public interface IActivityInstanceRepository : IRepository<ActivityInstance>
    {
        IQueryable<ActivityInstance> GetByActivityId(int activityId);
    }
}
