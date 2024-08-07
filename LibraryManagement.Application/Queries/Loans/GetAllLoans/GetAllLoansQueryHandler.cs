using LibraryManagement.Application.ViewModels;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Loans.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, List<LoanViewModel>>
    {
        private readonly LibraryManagementDbContext _dbContext;

        public GetAllLoansQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
