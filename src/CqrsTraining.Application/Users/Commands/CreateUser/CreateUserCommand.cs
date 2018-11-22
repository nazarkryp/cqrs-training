using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; }
    }
}
