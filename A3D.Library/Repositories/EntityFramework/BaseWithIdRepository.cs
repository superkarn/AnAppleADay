using A3D.Library.Models;
using A3D.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace A3D.Library.Repositories.EntityFramework
{
    public abstract class BaseWithIdRepository<TEntity> : BaseRepository<TEntity> where TEntity : BaseWithIdModel, new()
    {
        public BaseWithIdRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override int Create(TEntity item)
        {
            this.Context.Add(item);
            this.Context.SaveChanges();

            return item.Id;
        }

        public override void DeleteById(int id)
        {
            TEntity item = new TEntity() { Id = id };
            this.Context.Attach(item as TEntity);
            this.Context.Remove(item as TEntity);
            this.Context.SaveChanges();
        }

        public override void Update(TEntity item)
        {
            var entity = this.Context.Find(item.GetType(), item.Id);

            this.Context.Entry(entity).CurrentValues.SetValues(item);
            this.Context.SaveChanges();
        }
    }
}
