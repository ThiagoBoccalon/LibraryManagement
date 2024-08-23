using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Books.GetAllBooksWithParameter
{
    public class GetAllBooksWithParamaterQuery : IRequest<ResultViewModel<List<BookViewModel>>>
    {
        public GetAllBooksWithParamaterQuery(string query, BookStatusEnum status)
        {
            Query = query;
            Status = status;
        }

        public string Query { get; private set; }
        public BookStatusEnum Status { get; private set; }
    }
}
