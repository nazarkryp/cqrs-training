using System.Threading;
using System.Threading.Tasks;

using CqrsTraining.Application.Infrastructure.Exceptions;
using CqrsTraining.Dto;
using CqrsTraining.Persistence.Repositories;

using MediatR;

namespace CqrsTraining.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDto>
    {
        private readonly IUserRepository _users;

        public DeleteUserCommandHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task<UserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _users.FindAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            await _users.RemoveAsync(user);

            return new UserDto
            {
                UserId = user.UserId,
                Username = user.Username
            };
        }
    }
}
