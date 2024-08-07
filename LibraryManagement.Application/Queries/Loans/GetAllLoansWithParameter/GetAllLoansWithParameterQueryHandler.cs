using LibraryManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Loans.GetAllLoansWithParameter
{
    public class GetAllLoansWithParameterQueryHandler : IRequestHandler<GetAllLoansWithParameterQuery, List<LoanDetailsViewModel>>
    {
        public Task<List<LoanDetailsViewModel>> Handle(GetAllLoansWithParameterQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
