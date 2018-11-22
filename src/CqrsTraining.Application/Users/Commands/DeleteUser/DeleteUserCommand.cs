using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<UserDto>
    {
        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
