using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Domain.Entities;
using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _users;

        public CreateUserCommandHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username
            };

            user = await _users.AddAsync(user);

            return new UserDto
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }
    }
}
