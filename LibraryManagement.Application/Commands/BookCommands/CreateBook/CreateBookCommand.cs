using LibraryManagement.Application.InputModels;
using LibraryManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.BookCommands.CreateBook
{
    public class CreateBookCommand : IRequest<ResultViewModel<int>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }

        public Book ToEntity()
            => new(Title, Author, ISBN, PublicationYear);
    }
}
