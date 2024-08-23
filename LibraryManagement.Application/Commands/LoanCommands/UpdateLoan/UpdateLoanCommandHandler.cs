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

namespace LibraryManagement.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, ResultViewModel<Unit>>
    {
        private readonly ILoanRepository _loanRepository;

        public UpdateLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task<ResultViewModel<Unit>> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetByIdAsync(request.Id);

            loan.Update(request.IdUser, request.IdBook);

            await _loanRepository.SaveChangesAsync();

            return ResultViewModel<Unit>.Success(Unit.Value);
        }
    }
}
