using A3D.Library.Models;

namespace A3D.Library.Services.Interfaces
{
    public interface ICrudService<TEntity> where TEntity : BaseWithIdModel
    {
        int Create(TEntity item);
        void DeleteById(int id);
        TEntity GetById(int id);
        void Update(TEntity item);
    }
}
