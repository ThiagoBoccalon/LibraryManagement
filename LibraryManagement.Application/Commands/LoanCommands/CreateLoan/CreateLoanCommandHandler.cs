using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.CreateLoan
{
    internal class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, int>
    {
        public Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
