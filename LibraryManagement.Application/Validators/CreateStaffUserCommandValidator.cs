using FluentValidation;
using LibraryManagement.Application.Commands.UserCommands.CreateCommonUser;
using LibraryManagement.Application.Commands.UserCommands.CreateStaffUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validators
{
    public class CreateStaffUserCommandValidator : AbstractValidator<CreateStaffUserCommand>
    {
        public CreateStaffUserCommandValidator() 
        {
            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("This email is not acceptable");

            RuleFor(u => u.Password)
                .Must(ValidatePassword)
                .WithMessage("Your password doesn't contain at least a character, a number, an upper letter or an lower letter.");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Username has requested");

            RuleFor(u => u.PostCode)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Postcode has requested");

            RuleFor(u => u.Address)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Address has requested");

        }

        private bool ValidatePassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
