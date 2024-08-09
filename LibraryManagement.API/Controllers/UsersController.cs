using LibraryManagement.API.Models;
using LibraryManagement.Application.Commands.UserCommands.CreateCommonUser;
using LibraryManagement.Application.Commands.UserCommands.CreateStaffUser;
using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Queries.Users.GetUserById;
using LibraryManagement.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getUserByIdQuery= new GetUserByIdQuery(id);
            var user = await _mediator.Send(getUserByIdQuery);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("api/commonUser")]
        public async Task<IActionResult> PostCommonUser([FromBody] CreateCommonUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("api/staffUser")]
        public async Task<IActionResult> PostStaffUser([FromBody] CreateStaffUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoginModel inputModel)
        {
            //TODO later
            return NoContent();
        }
    }
}
