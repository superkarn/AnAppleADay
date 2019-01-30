﻿using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Repositories.Interfaces
{
    public interface IActivityRepository : IRepository<Activity>
    {
        IQueryable<Activity> GetByCreatorId(int creatorId);
    }
}