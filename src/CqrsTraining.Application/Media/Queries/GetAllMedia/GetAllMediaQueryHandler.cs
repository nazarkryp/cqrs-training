using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Media.Queries.GetAllMedia
{
    public class GetAllMediaQueryHandler : IRequestHandler<GetAllMediaQuery, IEnumerable<MediaDto>>
    {
        private readonly IMediaRepository _media;

        public GetAllMediaQueryHandler(IMediaRepository media)
        {
            _media = media;
        }

        public async Task<IEnumerable<MediaDto>> Handle(GetAllMediaQuery request, CancellationToken cancellationToken)
        {
            var media = await _media.FindAllAsync();

            return media.Select(m => new MediaDto
            {
                MediaId = m.MediaId,
                Url = m.Url
            });
        }
    }
}
