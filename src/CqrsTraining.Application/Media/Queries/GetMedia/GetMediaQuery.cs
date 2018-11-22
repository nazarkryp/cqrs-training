using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Media.Queries
{
    public class GetMediaQuery : IRequest<MediaDto>
    {
        public GetMediaQuery(int mediaId)
        {
            MediaId = mediaId;
        }

        public int MediaId { get; }
    }
}
