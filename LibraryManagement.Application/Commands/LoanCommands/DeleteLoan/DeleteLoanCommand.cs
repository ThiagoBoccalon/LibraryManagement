using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<string>
    {
        public DeleteLoanCommand(int id) 
        { 
            Id = id;
        }
        public int Id { get; private set; }
    }
}
