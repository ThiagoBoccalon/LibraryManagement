using LibraryManagement.Application.ViewModels;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Loans.GetLoanById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, LoanViewModel>
    {
        private LibraryManagementDbContext _dbContext;

        public GetLoanByIdQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoanViewModel> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _dbContext.Loans
                .SingleOrDefaultAsync(l => l.Id == request.Id);

            if (loan == null) return null;

            var loanViewModel = new LoanViewModel(
                loan.Id,
                loan.IdUser,
                loan.IdBook,
                loan.LoanAtStarted,
                loan.LoanForReturning
                );

            return loanViewModel;
        }
    }
}
