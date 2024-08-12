using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<Unit>
    {
        public UpdateLoanCommand(int id) 
        { 
            Id = id;
        }
        [JsonIgnore]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }        
    }
}
