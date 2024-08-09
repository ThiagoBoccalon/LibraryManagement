using LibraryManagement.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.UserCommands.CreateStaffUser
{
    public class CreateStaffUserCommand : IRequest<int>
    {
        private const string address = "237B Acton Lane";
        private const string postcode = "W4 5DL";
        public CreateStaffUserCommand()
        {
            Address = address;
            PostCode = postcode;
            Role = RoleEnum.StaffUserLibrary;
        }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Address { get; set; }
        [JsonIgnore]
        public string PostCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public RoleEnum Role { get; set; }
    }
}
