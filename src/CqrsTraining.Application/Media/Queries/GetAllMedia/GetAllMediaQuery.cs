using System.Collections.Generic;

using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Media.Queries.GetAllMedia
{
    public class GetAllMediaQuery : IRequest<IEnumerable<MediaDto>>
    {
    }
}
