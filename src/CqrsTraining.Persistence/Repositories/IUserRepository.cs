using System.Collections.Generic;
using System.Threading.Tasks;

using CqrsTraining.Domain.Entities;

namespace CqrsTraining.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAllAsync();

        Task<User> FindAsync(int userId);

        Task<User> AddAsync(User user);

        Task RemoveAsync(User user);
    }
}
