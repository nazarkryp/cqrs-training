using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Application.Infrastructure.Exceptions;
using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _users;

        public GetUserQueryHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _users.FindAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return new UserDto
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }
    }
}
