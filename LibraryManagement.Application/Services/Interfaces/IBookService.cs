using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services.Interfaces
{
    public interface IBookService
    {
        List<BookViewModel> GetAll(string query);
        BookViewModel GetById(int id);
        List<BookDetailsViewModel> GetAllWithParameter(string query, BookStatusEnum bookStatusEnum);
        int Create(NewBookInputModel inputModel);
        void Update(int id, UpdateBookInputModel inputModel);
        void Delete(int id);
    }
}
