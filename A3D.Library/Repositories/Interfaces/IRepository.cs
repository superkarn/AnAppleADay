using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        void Create(TEntity item);
        void Update(TEntity item);
    }
}
