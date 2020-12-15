using NordicBio.dal.Entities;
using System.Threading.Tasks;


namespace NordicBio.dal.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetByIDAsync(int id);
    }
}
