using LibraryManagement.Application.ViewModels;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Loans.GetAllLoansWithParameter
{
    public class GetAllLoansWithParameterQueryHandler : IRequestHandler<GetAllLoansWithParameterQuery, List<LoanDetailsViewModel>>
    {
        private LibraryManagementDbContext _dbContext;

        public GetAllLoansWithParameterQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LoanDetailsViewModel>> Handle(GetAllLoansWithParameterQuery request, CancellationToken cancellationToken)
        {
            var loansViewModel = _dbContext.Loans
                .Select(l => new LoanDetailsViewModel(
                    l.Id,
                    l.IdUser,
                    l.IdBook,
                    l.LoanAtStarted,
                    l.LoanForReturning,
                    l.Status
                    ))
                .AsEnumerable()
                .Where(l => l.Status == request.Status)
                .ToList();

            return loansViewModel;
        }
    }
}
