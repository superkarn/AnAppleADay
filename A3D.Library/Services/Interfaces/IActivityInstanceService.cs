using A3D.Library.Models;
using System.Collections.Generic;

namespace A3D.Library.Services.Interfaces
{
    public interface IActivityInstanceService : ICrudService<ActivityInstance>
    {
        IEnumerable<ActivityInstance> GetByActivityId(ApplicationContext context, int activityId);
    }
}
