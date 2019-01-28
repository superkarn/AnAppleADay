using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        TEntity GetById(int id);
        void DeleteById(int id);
    }
}
