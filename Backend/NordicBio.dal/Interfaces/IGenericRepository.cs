using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.dal.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Add(T entity);
        Task<int> Delete(int id);
    }
}
