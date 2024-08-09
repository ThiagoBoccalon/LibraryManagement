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
        private readonly LibraryManagementDbContext _dbContext;

        public ReturnLoandCommandHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _dbContext.Loans.SingleOrDefaultAsync(l => l.Id == request.Id);

            var bookForGettingAvailible = await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == loan.IdBook);

            bookForGettingAvailible.GettingBookAvaililable();

            var message = loan.Return(DateTime.Now);

            await _dbContext.SaveChangesAsync();

            return message;
        }
    }
}
