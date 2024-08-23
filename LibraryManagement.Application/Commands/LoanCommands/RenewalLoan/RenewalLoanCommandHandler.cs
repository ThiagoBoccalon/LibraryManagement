using LibraryManagement.Application.InputModels;
using LibraryManagement.Core.Repositories;
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
    public class RenewalLoanCommandHandler : IRequestHandler<RenewalLoanCommand, ResultViewModel<string>>
    {
        private ILoanRepository _loanRepository;

        public RenewalLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<string>> Handle(RenewalLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            var message = loan.Renewal();

            await _loanRepository.SaveChangesAsync();

            return ResultViewModel<string>.Success(message);
        }
    }
}
