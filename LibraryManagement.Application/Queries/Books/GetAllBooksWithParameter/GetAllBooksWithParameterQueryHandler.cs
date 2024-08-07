using LibraryManagement.Application.ViewModels;
using LibraryManagement.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Books.GetAllBooksWithParameter
{
    public class GetAllBooksWithParameterQueryHandler : IRequestHandler<GetAllBooksWithParamaterQuery, List<BookViewModel>>
    {
        private readonly LibraryManagementDbContext _dbContext;

        public GetAllBooksWithParameterQueryHandler(LibraryManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<BookViewModel>> Handle(GetAllBooksWithParamaterQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
