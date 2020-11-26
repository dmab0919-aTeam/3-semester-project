using System.Collections.Generic;

namespace NordicBio.dal.Interfaces
{
    public interface ICRUD<T>
    {
        bool Create(T t);
        T Get(int id);
        IEnumerable<T> GetAll();
        bool Update(T t);
        bool Delete(T t);
    }
}
