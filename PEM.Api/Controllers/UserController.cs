using MediatR;
using Microsoft.AspNetCore.Mvc;
using PEM.Application.Commands.User.CreateUser;
using PEM.Application.Queries.GetUserById;

namespace PEM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery(id);

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, result);
        }
    }
}
