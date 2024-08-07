using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.ReturnLoan
{
    public class ReturnLoandCommandHandler : IRequestHandler<ReturnLoanCommand, Unit>
    {
        public Task<Unit> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
