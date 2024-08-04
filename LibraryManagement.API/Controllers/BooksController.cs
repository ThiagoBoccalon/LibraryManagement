using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var books = _bookService.GetAll(query);

            return Ok(books);
        }

        [HttpGet("/withStatus")]
        public IActionResult GetAllWithParameter(string query, BookStatusEnum bookStatusEnum)
        {
            var book = _bookService.GetAllWithParameter(query, bookStatusEnum);

            return Ok(book);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewBookInputModel inputModel)
        {
            var id = _bookService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookInputModel inputModel)
        {
            _bookService.Update(id, inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);

            return NoContent();
        }
    }
}
