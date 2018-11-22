using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Media.Commands.CreateMedia
{
    public class CreateMediaCommand : IRequest<MediaDto>
    {
        public string Url { get; set; }
    }
}
