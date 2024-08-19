using LibraryManagement.Application.InputModels;
using LibraryManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {
        public GetUserByIdQuery(int id) 
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
