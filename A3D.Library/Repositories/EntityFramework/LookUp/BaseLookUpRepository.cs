using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace A3D.Library.Repositories.EntityFramework.LookUp
{
    public abstract class BaseLookUpRepository<TEntity> : ILookUpRepository<TEntity> where TEntity : BaseLookUpModel
    {
        readonly ApplicationDbContext Context;
        readonly DbSet<TEntity> DbSet;

        public BaseLookUpRepository(ApplicationDbContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.DbSet;
        }
    }
}
