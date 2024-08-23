using LibraryManagement.Application.InputModels;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.CreateLoan
{
    internal class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, ResultViewModel<int>>
    {
        private readonly ILoanRepository _loanRepository;
        public CreateLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = request.ToEntity();

            await _loanRepository.CreateLoanAsync(loan);
            await _loanRepository.SaveChangesAsync();
            
            return ResultViewModel<int>.Success(loan.Id);
        }
    }
}
