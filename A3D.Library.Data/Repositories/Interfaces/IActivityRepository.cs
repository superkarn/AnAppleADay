using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Data.Repositories.Interfaces
{
    public interface IActivityRepository : ICrudRepository<Activity>
    {
        IQueryable<Activity> GetByCreatorId(string creatorId);
    }
}
