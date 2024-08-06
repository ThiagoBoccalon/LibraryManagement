using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string isbn, int publicationYear, BookStatusEnum status)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
            Status = status;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }        
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public BookStatusEnum Status { get; private set; }
    }
}
