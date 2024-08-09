using LibraryManagement.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {   
        public UpdateBookCommand(int id)
        {
            Id = id;
        }
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public BookStatusEnum Status { get; set; }
    }
}
