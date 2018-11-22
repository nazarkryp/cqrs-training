using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using CqrsTraining.Application.Users.Commands.CreateUser;
using CqrsTraining.Application.Users.Commands.DeleteUser;
using CqrsTraining.Application.Users.Queries.GetUser;
using CqrsTraining.Dto;
using CqrsTraining.Dto.Results;
using CqrsTraining.Persistence.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace CqrsTraining.Web.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserRepository _users;

        public UsersController(IUserRepository users)
        {
            _users = users;
        }

        [ProducesResponseType(typeof(DataResult<IEnumerable<UserDto>>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _users.FindAllAsync();

            var userDtos = users.Select(e => new UserDto
            {
                UserId = e.UserId,
                Username = e.Username
            });

            var result = new DataResult<IEnumerable<UserDto>>(userDtos);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand createUserCommand)
        {
            var user = await Mediator.Send(createUserCommand);

            var actionName = nameof(GetUserAsync);
            return CreatedAtAction(actionName, new { userId = user.UserId }, user);
        }

        [HttpGet, Route("{userId:int}")]
        public async Task<IActionResult> GetUserAsync(int userId)
        {
            var query = new GetUserQuery(userId);
            var media = await Mediator.Send(query);

            return Ok(media);
        }

        [HttpDelete, Route("{userId:int}")]
        public async Task<IActionResult> RemoveUserAsync(int userId)
        {
            var query = new DeleteUserCommand(userId);
            await Mediator.Send(query);

            return NoContent();
        }
    }
}
