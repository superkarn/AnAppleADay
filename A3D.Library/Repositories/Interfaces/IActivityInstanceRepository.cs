using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Repositories.Interfaces
{
    public interface IActivityInstanceRepository : IWithIdRepository<ActivityInstance>
    {
        IQueryable<ActivityInstance> GetByActivityId(int activityId);
    }
}
