using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _users;

        public GetAllUsersQueryHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _users.FindAllAsync();

            return users.Select(user => new UserDto
            {
                UserId = user.UserId,
                Username = user.Username
            });
        }
    }
}
