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
        Task<List<int>> AddSeatAsync(List<Seat> entityList);

        Task<IEnumerable<Seat>> GetAllByOrderIdAsync(int id);
    }
}
