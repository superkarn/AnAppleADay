using A3D.Library.Models;
using System;
using System.Collections.Generic;

namespace A3D.Library.Services.Interfaces
{
    public interface IActivityService : ICrudService<Activity>
    {
        IEnumerable<Activity> GetByCreatorId(ApplicationContext context, Guid creatorId);
        IEnumerable<Activity> GetByCreatorUsername(ApplicationContext context, string username);
    }
}
