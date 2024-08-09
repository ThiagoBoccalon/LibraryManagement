using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Unit>
    {
        private readonly LibraryManagementDbContext _dbContext;

        public UpdateLoanCommandHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = _dbContext.Loans.FirstOrDefault(l => l.Id == request.Id);

            loan.Update(request.IdUser, request.IdBook);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
