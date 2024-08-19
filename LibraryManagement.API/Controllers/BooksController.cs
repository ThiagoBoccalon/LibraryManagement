using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using LibraryManagement.Application.Commands.BookCommands.DeleteBook;
using LibraryManagement.Application.Commands.BookCommands.UpdateBook;
using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Queries.Books.GetAllBooks;
using LibraryManagement.Application.Queries.Books.GetAllBooksWithParameter;
using LibraryManagement.Application.Queries.Books.GetBookById;
using LibraryManagement.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/books")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllBooksQuery = new GetAllBooksQuery(query);
            var books = await _mediator.Send(getAllBooksQuery);

            return Ok(books);
        }

        [HttpGet("/withStatus")]
        public async Task<IActionResult> GetAllWithParameter(string query, BookStatusEnum bookStatusEnum)
        {
            var getAllWithParameter = new GetAllBooksWithParamaterQuery(query, bookStatusEnum);
            var books = await _mediator.Send(getAllWithParameter);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getBookByIdQuery = new GetBookByIdQuery(id);
            var result = await _mediator.Send(getBookByIdQuery);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBookCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteBookCommand = new DeleteBookCommand(id);
            await _mediator.Send(deleteBookCommand);
            
            return NoContent();
        }
    }
}
