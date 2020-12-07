using NordicBio.dal.Entities;
using System.Threading.Tasks;

namespace NordicBio.dal.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<int> Delete(string email);
    }
}
