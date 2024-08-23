using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Repositories;
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
    public class GetAllLoansWithParameterQueryHandler : IRequestHandler<GetAllLoansWithParameterQuery, ResultViewModel<List<LoanDetailsViewModel>>>
    {
        private ILoanRepository _loanRepository;

        public GetAllLoansWithParameterQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<List<LoanDetailsViewModel>>> Handle(GetAllLoansWithParameterQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetLoansWithParameterAsync(request.Status);

            var loansViewModel = loans
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

            return ResultViewModel<List<LoanDetailsViewModel>>.Success(loansViewModel);
        }
    }
}
