using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using CqrsTraining.Application.Media.Commands.CreateMedia;
using CqrsTraining.Application.Media.Commands.DeleteMedia;
using CqrsTraining.Application.Media.Queries;
using CqrsTraining.Application.Media.Queries.GetAllMedia;
using CqrsTraining.Dto;
using CqrsTraining.Dto.Results;

using Microsoft.AspNetCore.Mvc;

namespace CqrsTraining.Web.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MediaController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(DataResult<IEnumerable<MediaDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetMediaAsync()
        {
            var query = new GetAllMediaQuery();
            var media = await Mediator.Send(query);

            var result = new DataResult<IEnumerable<MediaDto>>(media);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMediaAsync([FromBody] CreateMediaCommand command)
        {
            var media = await Mediator.Send(command);

            var actionName = nameof(GetMediaAsync);
            return CreatedAtAction(actionName, new { mediaId = media.MediaId }, media);
        }

        [HttpGet, Route("{mediaId:int}")]
        public async Task<IActionResult> GetMediaAsync(int mediaId)
        {
            var query = new GetMediaQuery(mediaId);
            var media = await Mediator.Send(query);

            return Ok(media);
        }

        [HttpDelete, Route("{mediaId:int}")]
        public async Task<IActionResult> RemoveMediaAsync(int mediaId)
        {
            var query = new DeleteMediaCommand(mediaId);
            await Mediator.Send(query);

            return NoContent();
        }
    }
}