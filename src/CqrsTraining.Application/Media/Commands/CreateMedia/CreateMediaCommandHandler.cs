using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Media.Commands.CreateMedia
{
    public class CreateMediaCommandHandler : IRequestHandler<CreateMediaCommand, MediaDto>
    {
        private readonly IMediaRepository _media;

        public CreateMediaCommandHandler(IMediaRepository media)
        {
            _media = media;
        }

        public async Task<MediaDto> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
        {
            var media = new Domain.Entities.Media
            {
                Url = request.Url
            };

            media = await _media.AddMediaAsync(media);

            var mediaDto = new MediaDto
            {
                MediaId = media.MediaId,
                Url = media.Url
            };

            return mediaDto;
        }
    }
}
