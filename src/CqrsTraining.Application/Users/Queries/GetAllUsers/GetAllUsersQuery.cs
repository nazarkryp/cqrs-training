using System.Collections.Generic;

using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
