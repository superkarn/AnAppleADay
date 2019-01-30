using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Repositories.Interfaces
{
    public interface IWithIdRepository<TEntity> where TEntity : BaseModel
    {
        int Create(TEntity item);
        void DeleteById(int id);
        TEntity GetById(int id);
        void Update(TEntity item);
    }
}
