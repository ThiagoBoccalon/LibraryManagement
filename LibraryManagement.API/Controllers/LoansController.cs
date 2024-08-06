using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly IBookService _bookServise;
        public LoansController(ILoanService loanService, IBookService bookService)
        {
            _loanService = loanService;
            _bookServise = bookService;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var loans = _loanService.GetAll(query);

            return Ok(loans);
        }

        [HttpGet("/withParameter")]
        public IActionResult GetAllWithParameter(string query, LoanStatusEnum loanStatusEnum)
        {
            var loans = _loanService.GetAllWithParameter(query, loanStatusEnum);

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loan = _loanService.GetById(id);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewLoanInputModel inputModel)
        {
            var id = _loanService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLoanInputModel inputModel)
        {
            _loanService.Update(id, inputModel);

            return NoContent();
        }

        [HttpPut("{id}/return")]
        public IActionResult Return(int id)
        {
            var loanRequest = _loanService.GetById(id);

            if (loanRequest == null) return NotFound();

            _bookServise.Delete(loanRequest.IdBook);

            var loan = _loanService.Return(id);

            if (loan == null) return NotFound();

            return Ok(loan);
        }

        /*
         * This method has two steps
         * Firs: Changing status of Bool from Unavailible to Availible
         * Second: Delete if conditions allow the loan existed.
         */
        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var loanRequest = _loanService.GetById(id);

            if (loanRequest == null) return NotFound();

            _bookServise.Delete(loanRequest.IdBook);

            var loan = _loanService.Delete(id);

            return Ok(loan);
        }
    }
}
