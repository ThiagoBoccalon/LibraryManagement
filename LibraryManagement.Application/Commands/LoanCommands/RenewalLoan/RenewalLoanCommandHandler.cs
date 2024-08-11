using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.RenewalLoan
{
    public class RenewalLoanCommandHandler : IRequestHandler<RenewalLoanCommand, string>
    {
        private LibraryManagementDbContext _dbContext;

        public RenewalLoanCommandHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(RenewalLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _dbContext.Loans.SingleOrDefaultAsync(l => l.Id == request.Id);

            var message = loan.Renewal();

            await _dbContext.SaveChangesAsync();

            return message;
        }
    }
}
