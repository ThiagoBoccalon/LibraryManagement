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

namespace LibraryManagement.Application.Queries.Loans.GetLoanById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, ResultViewModel<LoanViewModel>>
    {
        private ILoanRepository _loanRepository;

        public GetLoanByIdQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<LoanViewModel>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            if (loan == null) return null;

            var loanViewModel = new LoanViewModel(
                loan.Id,
                loan.IdUser,
                loan.IdBook,
                loan.LoanAtStarted,
                loan.LoanForReturning
                );

            return ResultViewModel<LoanViewModel>.Success(loanViewModel);
        }
    }
}
