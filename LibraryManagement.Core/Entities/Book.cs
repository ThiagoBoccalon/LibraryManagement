using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title,
            string author,
            string isbn,
            int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
            Status = BookStatusEnum.Available;
        }
        public string Title { get; set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public BookStatusEnum Status { get; private set; }
    }
}
