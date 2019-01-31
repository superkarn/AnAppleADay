using A3D.Library.Models;
using System.Collections.Generic;

namespace A3D.Library.Services.Interfaces
{
    public interface IActivityService : ICrudService<Activity>
    {
        IEnumerable<Activity> GetByCreatorId(int creatorId);
    }
}
