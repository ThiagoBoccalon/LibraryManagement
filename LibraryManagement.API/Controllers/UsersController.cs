using LibraryManagement.API.Models;
using LibraryManagement.Application.Commands.UserCommands.CreateCommonUser;
using LibraryManagement.Application.Commands.UserCommands.CreateStaffUser;
using LibraryManagement.Application.Commands.UserCommands.LoginUser;
using LibraryManagement.Application.Commands.UserCommands.UpdateUser;
using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Queries.Users.GetUserById;
using LibraryManagement.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryManagement.API.Controllers
{
    [Route("api/users")]
    [Authorize]
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
            var result = await _mediator.Send(getUserByIdQuery);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("api/commonUser")]
        [AllowAnonymous]
        public async Task<IActionResult> PostCommonUser([FromBody] CreateCommonUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, command);
        }

        [HttpPost("api/staffUser")]
        [AllowAnonymous]
        public async Task<IActionResult> PostStaffUser([FromBody] CreateStaffUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("api/updateUser")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserCommand command)
        {
            return NoContent();
        }
        
        [HttpPut("api/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {            
            var loginUserviewModel = await _mediator.Send(command);

            if (loginUserviewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserviewModel);
        }        
    }
}
