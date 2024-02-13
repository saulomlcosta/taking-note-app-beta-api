using MediatR;
using Microsoft.AspNetCore.Mvc;
using TakingNoteApp.Application.UseCases.Login.Commands;

namespace TakingNoteApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
