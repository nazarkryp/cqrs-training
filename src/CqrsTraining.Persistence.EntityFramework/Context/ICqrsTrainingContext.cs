using System.Threading.Tasks;

using CqrsTraining.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CqrsTraining.Persistence.EntityFramework.Context
{
    public interface ICqrsTrainingContext
    {
        DbSet<Media> Media { get; set; }

        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();
    }
}
