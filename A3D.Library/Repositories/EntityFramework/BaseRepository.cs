using A3D.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace A3D.Library.Repositories.EntityFramework
{
    public abstract class BaseRepository<TEntity> where TEntity : BaseModel, new()
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }
    }
}
