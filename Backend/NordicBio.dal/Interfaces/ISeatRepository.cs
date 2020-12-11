using NordicBio.dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.dal.Interfaces
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<int> DeleteOldSeatsAsync(int id);
        Task<IEnumerable<Seat>> GetAllByIdAsync(int id);
        Task<int> BuySeatAsync(Seat entity);
    }
}
