using A3D.Library.Models;

namespace A3D.Library.Data.Repositories.Interfaces
{
    public interface ICrudRepository<TEntity> where TEntity : BaseWithIdModel
    {
        int Create(TEntity item);
        void DeleteById(int id);
        TEntity GetById(int id);
        void Update(TEntity item);
    }
}
