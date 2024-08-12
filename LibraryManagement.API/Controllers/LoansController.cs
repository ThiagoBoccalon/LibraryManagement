using LibraryManagement.Application.Commands.LoanCommands.CreateLoan;
using LibraryManagement.Application.Commands.LoanCommands.DeleteLoan;
using LibraryManagement.Application.Commands.LoanCommands.RenewalLoan;
using LibraryManagement.Application.Commands.LoanCommands.ReturnLoan;
using LibraryManagement.Application.Commands.LoanCommands.UpdateLoan;
using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.Queries.Books.GetAllBooks;
using LibraryManagement.Application.Queries.Books.GetAllBooksWithParameter;
using LibraryManagement.Application.Queries.Loans.GetAllLoans;
using LibraryManagement.Application.Queries.Loans.GetAllLoansWithParameter;
using LibraryManagement.Application.Queries.Loans.GetLoanById;
using LibraryManagement.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string query)
        {
            var getAllBooksQuery = new GetAllLoansQuery(query);
            var loans = await _mediator.Send(getAllBooksQuery);

            return Ok(loans);
        }

        [HttpGet("/withParameter")]
        public async Task<IActionResult> GetAllWithParameter(string query, LoanStatusEnum status)
        {
            var getAllWithParameter = new GetAllLoansWithParameterQuery(query, status);
            var loans = await _mediator.Send(getAllWithParameter);
                
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getLoanById = new GetLoanByIdQuery(id);
            var loan = await _mediator.Send(getLoanById);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {            
            var id = await _mediator.Send(command);                

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        /*
         * Put for Renewal Loan must be to do soon.
         */

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLoanCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> Return(int id)
        {

            var returnLoanCommand = new ReturnLoanCommand(id);
            var messageResult = await _mediator.Send(returnLoanCommand);

            if (messageResult == null) return NotFound();
                        
            return Ok(messageResult);
        }

        [HttpPut("{id}/renewal")]
        public async Task<IActionResult> Renewal(int id)
        {

            var returnLoanCommand = new RenewalLoanCommand(id);
            var messageResult = await _mediator.Send(returnLoanCommand);

            if (messageResult == null) return NotFound();

            return Ok(messageResult);
        }

        /*
         * This method has two steps
         * Firs: Changing status of Bool from Unavailible to Availible
         * Second: Delete if conditions allow the loan existed.
         */
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteLoanCommand = new DeleteLoanCommand(id);
            var messageResult = await _mediator.Send(deleteLoanCommand);

            return Ok(messageResult);
        }
    }
}
