using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Application.Infrastructure.Exceptions;
using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Media.Queries
{
    public class GetMediaQueryHander : IRequestHandler<GetMediaQuery, MediaDto>
    {
        private readonly IMediaRepository _media;

        public GetMediaQueryHander(IMediaRepository media)
        {
            _media = media;
        }

        public async Task<MediaDto> Handle(GetMediaQuery request, CancellationToken cancellationToken)
        {
            var media = await _media.FindAsync(request.MediaId);

            if (media == null)
            {
                throw new NotFoundException("Media not found");
            }

            return new MediaDto
            {
                MediaId = media.MediaId,
                Url = media.Url
            };
        }
    }
}
