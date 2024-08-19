using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Books.GetBookById
{
    public class GetBookByIdQuery : IRequest<ResultViewModel<BookViewModel>>
    {
        public GetBookByIdQuery(int id) 
        { 
            Id = id;
        }

        public int Id { get; private set; }
    }
}
