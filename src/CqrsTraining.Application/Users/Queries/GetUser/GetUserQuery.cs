using CqrsTraining.Dto;

using MediatR;

namespace CqrsTraining.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public GetUserQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
