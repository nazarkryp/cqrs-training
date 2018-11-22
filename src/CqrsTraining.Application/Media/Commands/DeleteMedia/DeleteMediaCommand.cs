using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Media.Commands.DeleteMedia
{
    public class DeleteMediaCommand : IRequest<MediaDto>
    {
        public DeleteMediaCommand(int mediaId)
        {
            MediaId = mediaId;
        }

        public int MediaId { get; set; }
    }
}
