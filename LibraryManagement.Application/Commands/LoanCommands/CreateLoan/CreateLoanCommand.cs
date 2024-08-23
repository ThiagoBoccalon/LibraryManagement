using LibraryManagement.Application.InputModels;
using LibraryManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.CreateLoan
{
    public class CreateLoanCommand : IRequest<ResultViewModel<int>>
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }

        public Loan ToEntity()
            => new(IdUser, IdBook);
    }
}
