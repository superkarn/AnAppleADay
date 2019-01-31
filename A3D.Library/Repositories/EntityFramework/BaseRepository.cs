using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace A3D.Library.Repositories.EntityFramework
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel, new()
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        public abstract void Create(TEntity item);

        public abstract void Update(TEntity item);
    }
}
