using A3D.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace A3D.Library.Services.Interfaces
{
    public interface ICrudService<T> where T : BaseModel
    {
        int Create(T obj);
        T GetById(int id);
        void Update(T obj);
        void Delete(int id);
    }
}
