using LibraryManagement.Application.InputModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommand : IRequest<ResultViewModel<Unit>>
    {
        public DeleteBookCommand(int id) 
        { 
            Id = id;
        }

        public int Id { get; private set; }
    }
}
