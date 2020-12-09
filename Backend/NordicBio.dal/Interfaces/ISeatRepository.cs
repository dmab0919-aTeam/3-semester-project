using NordicBio.dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordicBio.dal.Interfaces
{
    public interface ISeatRepository : IGenericRepository<Seat>
    {
        Task<IEnumerable<Seat>> GetAllById(int id);
        Task<int> DeleteOldSeats(int id);
    }
}
