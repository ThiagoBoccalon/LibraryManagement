using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Loans.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<ResultViewModel<List<LoanViewModel>>>
    {
        public GetAllLoansQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
