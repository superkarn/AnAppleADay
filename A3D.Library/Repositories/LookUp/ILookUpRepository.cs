using A3D.Library.Models;
using System.Linq;

namespace A3D.Library.Repositories.LookUp
{
    public interface ILookUpRepository<TEntity> where TEntity : BaseLookUpModel
    {
        IQueryable<TEntity> GetAll();
    }
}
