using NordicBio.dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.dal.Interfaces
{
    public interface IShowingRepository : IGenericRepository<Showing>
    {
        Task<IEnumerable<Showing>> GetShowingsByIDAsync(int id);
        Task<Showing> GetByIDAsync(int id);
    }
}
