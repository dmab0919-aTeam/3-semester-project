using NordicBio.dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.dal.Interfaces
{
    public interface IShowingRepository : IGenericRepository<Showing>
    {
        Task<IEnumerable<Showing>> GetShowingsByID(int id);
    }
}
