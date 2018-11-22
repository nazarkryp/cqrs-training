using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CqrsTraining.Domain.Entities;
using CqrsTraining.Persistence.EntityFramework.Context;
using CqrsTraining.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

namespace CqrsTraining.Persistence.EntityFramework.Concrete
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ICqrsTrainingContext _context;

        public MediaRepository(ICqrsTrainingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> FindAllAsync()
        {
            return await _context.Media
                .OrderByDescending(e => e.MediaId)
                .ToListAsync();
        }

        public Task<Media> FindAsync(int mediaId)
        {
            return _context.Media.FirstOrDefaultAsync(e => e.MediaId == mediaId);
        }

        public async Task<Media> AddMediaAsync(Media media)
        {
            var entry = await _context.Media.AddAsync(media);

            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public Task RemoveMediaAsync(Media media)
        {
            _context.Media.Remove(media);

            return _context.SaveChangesAsync();
        }
    }
}
