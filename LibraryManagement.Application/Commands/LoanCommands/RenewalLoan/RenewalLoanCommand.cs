using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.RenewalLoan
{
    public class RenewalLoanCommand : IRequest<string>
    {
        public RenewalLoanCommand(int id)         
        { 
            Id = id;
        }

        public int Id { get; set; }
    }
}
