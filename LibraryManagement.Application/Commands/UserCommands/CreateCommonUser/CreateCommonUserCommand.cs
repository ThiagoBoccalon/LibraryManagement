using LibraryManagement.Application.InputModels;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.CreateCommonUser
{
    public class CreateCommonUserCommand : IRequest<ResultViewModel<int>>
    {
        public CreateCommonUserCommand() 
        { 
            Role = RoleEnum.CommonUserLibrary;
        }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public RoleEnum Role { get; set; }

        public User ToEntity()
            => new(UserName, Email, Password, Address, PostCode, Role);
    }
}
