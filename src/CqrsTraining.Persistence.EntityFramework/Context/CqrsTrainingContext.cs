using System.Threading.Tasks;

using CqrsTraining.Domain.Entities;
using CqrsTraining.Persistence.EntityFramework.Extensions;

using Microsoft.EntityFrameworkCore;

namespace CqrsTraining.Persistence.EntityFramework.Context
{
    public class CqrsTrainingContext : DbContext, ICqrsTrainingContext
    {
        public CqrsTrainingContext(DbContextOptions<CqrsTrainingContext> options)
            : base(options)
        {
        }

        public DbSet<Media> Media { get; set; }

        public DbSet<User> Users { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations(typeof(CqrsTrainingContext));
        }
    }
}
