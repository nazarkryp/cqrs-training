using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Application.Infrastructure.Exceptions;
using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Media.Commands.DeleteMedia
{
    public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand, MediaDto>
    {
        private readonly IMediaRepository _media;

        public DeleteMediaCommandHandler(IMediaRepository media)
        {
            _media = media;
        }

        public async Task<MediaDto> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
        {
            var media = await _media.FindAsync(request.MediaId);

            if (media == null)
            {
                throw new NotFoundException("Media not found");
            }

            await _media.RemoveMediaAsync(media);

            return new MediaDto
            {
                MediaId = media.MediaId,
                Url = media.Url
            };
        }
    }
}
