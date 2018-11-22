using System.Collections.Generic;
using System.Threading.Tasks;

using CqrsTraining.Domain.Entities;

namespace CqrsTraining.Persistence.Repositories
{
    public interface IMediaRepository
    {
        Task<IEnumerable<Media>> FindAllAsync();

        Task<Media> FindAsync(int mediaId);

        Task<Media> AddMediaAsync(Media media);

        Task RemoveMediaAsync(Media media);
    }
}
