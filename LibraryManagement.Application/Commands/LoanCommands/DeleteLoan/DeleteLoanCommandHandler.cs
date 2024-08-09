using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, string>
    {
        private readonly LibraryManagementDbContext _dbContext;

        public DeleteLoanCommandHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _dbContext.Loans.SingleOrDefaultAsync(l => l.Id == request.Id);

            var message = loan.Delete();

            await _dbContext.SaveChangesAsync();

            return message;
        }
    }
}
