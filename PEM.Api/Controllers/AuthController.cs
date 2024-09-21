using MediatR;
using Microsoft.AspNetCore.Mvc;
using PEM.Application.Commands.Auth;

namespace PEM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
