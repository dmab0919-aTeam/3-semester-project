using NordicBio.dal.Entities;
using System.Threading.Tasks;

namespace NordicBio.dal.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

    }
}
