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
    public interface ILoanService
    {   
        int Create(NewLoanInputModel inputModel);
        void Update(int id, UpdateLoanInputModel inputModel);
        string Renewal(int id);
        string Return(int id);
        string Delete(int id);
    }
}
