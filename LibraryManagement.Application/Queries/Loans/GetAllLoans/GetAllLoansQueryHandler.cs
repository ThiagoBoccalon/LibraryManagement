using LibraryManagement.Application.ViewModels;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Queries.Loans.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoanViewModel>>
    {
        private readonly LibraryManagementDbContext _dbContext;

        public GetAllLoansQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = _dbContext.Loans;

            var loansViewModel = await loans
                .Select(l => new LoanViewModel(l.Id, l.IdUser, l.IdBook, l.LoanAtStarted, l.LoanForReturning))
                .ToListAsync();

            return loansViewModel;
        }
    }
}
