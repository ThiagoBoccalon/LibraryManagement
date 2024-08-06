using LibraryManagement.API.Models;
using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("api/commonUser")]
        public IActionResult PostCommonUser([FromBody] CreateUserCommonInputModel inputModel)
        {
            var id = _userService.CreateUserCommon(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPost("api/staffUser")]
        public IActionResult PostStaffuser([FromBody] CreateUserStaffInputModel inputModel)
        {
            var id = _userService.CreateUserStaff(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoginModel inputModel)
        {
            //TODO later
            return NoContent();
        }
    }
}
