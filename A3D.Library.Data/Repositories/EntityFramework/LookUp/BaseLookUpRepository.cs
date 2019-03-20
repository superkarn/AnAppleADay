using A3D.Library.Data.Data;
using A3D.Library.Data.Repositories.Interfaces;
using A3D.Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace A3D.Library.Data.Repositories.EntityFramework.LookUp
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
