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
        protected Book() { }
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

        public void Update(string title, string author, string isbn, int publicationYear, BookStatusEnum status)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
            Status = status;
        }

        public void GettingBookAvaililable()
        {
            if (Status == BookStatusEnum.Unvailable)
                Status = BookStatusEnum.Available;
        }

        public void GettingBookUnvailible()
        {
            if (Status == BookStatusEnum.Available)
                Status = BookStatusEnum.Unvailable;
        }

        public void GettingBookDeleted()
        {
            if (Status != BookStatusEnum.Deleted)
                Status = BookStatusEnum.Deleted;
        }

    }
}
