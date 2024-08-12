using FluentValidation;
using LibraryManagement.Application.Commands.BookCommands.UpdateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .WithMessage("Maximium lenght of title must have less than 100 character");

            RuleFor(b => b.Author)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .WithMessage("Maximium lenght of author must have less than 50 character");

            RuleFor(b => b.ISBN)
                .NotEmpty()
                .NotNull()
                .Length(16)
                .WithMessage("Maximium lenght of ISBN must have 16 character");
        }
    }
}
