using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.ReturnLoan
{
    public class ReturnLoandCommandHandler : IRequestHandler<ReturnLoanCommand, string>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;

        public ReturnLoandCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
        }
        public async Task<string> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            var bookForGettingAvailible = await _bookRepository.GetByIdAsync(loan.Id);   

            bookForGettingAvailible.GettingBookAvaililable();

            var message = loan.Return(DateTime.Now);

            await _loanRepository.SaveChangesAsync();

            return message;
        }
    }
}
