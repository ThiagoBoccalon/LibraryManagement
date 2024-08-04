using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.ViewModels
{
    public class BookDetailsViewModel : BookViewModel
    {
        public BookDetailsViewModel(int id, string title, string author, string isbn, int publicationYear, BookStatusEnum status) : base(id, title, author, isbn, publicationYear)
        {
            Status = status;
        }
        public BookStatusEnum Status { get; private set; }
    }
}
