using FluentValidation;
using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using LibraryManagement.Application.Commands.UserCommands.CreateCommonUser;
using LibraryManagement.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validators
{
    public class CreateCommonUserCommandValidator : AbstractValidator<CreateUserCommonInputModel>
    {
        public CreateCommonUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotNull()
                    .WithMessage("User can't be null")
                .NotEmpty()
                    .WithMessage("User can't be empty")
                .EmailAddress()
                    .WithMessage("This email is not acceptable");

            RuleFor(u => u.Password)
                .NotEmpty()
                    .WithMessage("Password can't be empty")
                .Must(ValidatePassword)
                .WithMessage("Your password doesn't contain at least a character, a number, an upper letter or an lower letter.");

            RuleFor(u => u.UserName)
                .NotEmpty()                
                .WithMessage("Username has requested");

            RuleFor(u => u.PostCode)
                .NotEmpty()                
                .WithMessage("Postcode has requested");

            RuleFor(u => u.Address)
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
