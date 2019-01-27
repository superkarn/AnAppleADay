using A3D.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace A3D.Library.Services.Interfaces
{
    public interface IActivityService : ICrudService<Activity>
    {
        IEnumerable<Activity> GetByOwnerId(int ownerId);
    }
}
