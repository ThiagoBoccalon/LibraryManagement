using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Queries.Loans.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, ResultViewModel<List<LoanViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllAsync();

            var loansViewModel = loans
                .Select(l => new LoanViewModel(l.Id, l.IdUser, l.IdBook, l.LoanAtStarted, l.LoanForReturning))
                .ToList();
            var x = ResultViewModel<List<LoanViewModel>>.Success(loansViewModel);
            return x;
        }
    }
}
