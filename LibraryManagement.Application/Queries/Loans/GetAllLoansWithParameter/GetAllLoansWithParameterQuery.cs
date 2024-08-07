using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Loans.GetAllLoansWithParameter
{
    public class GetAllLoansWithParameterQuery : IRequest<List<LoanDetailsViewModel>>
    {
        public GetAllLoansWithParameterQuery(string query, LoanStatusEnum status)
        {
            Query = query;
            Status = status;
        }

        public string Query { get; private set; }
        public LoanStatusEnum Status { get; private set; }
    }
}
