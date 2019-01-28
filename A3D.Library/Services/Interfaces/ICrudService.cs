using A3D.Library.Models;

namespace A3D.Library.Services.Interfaces
{
    public interface ICrudService<T> where T : BaseModel
    {
        int Create(T item);
        T GetById(int id);
        void Update(T item);
        void DeleteById(int id);
    }
}
