using LibraryManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Loans.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<LoanViewModel>
    {
        public GetLoanByIdQuery(int id) 
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
