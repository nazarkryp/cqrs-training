using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CqrsTraining.Domain.Entities;
using CqrsTraining.Persistence.EntityFramework.Context;
using CqrsTraining.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace CqrsTraining.Persistence.EntityFramework.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly ICqrsTrainingContext _context;

        public UserRepository(ICqrsTrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await _context.Users
                .OrderByDescending(e => e.UserId)
                .ToListAsync();
        }

        public async Task<User> FindAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.UserId == userId);

            return user;
        }

        public async Task<User> AddAsync(User user)
        {
            var entry = await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public Task RemoveAsync(User user)
        {
            _context.Users.Remove(user);

            return _context.SaveChangesAsync();
        }
    }
}
