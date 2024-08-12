using FluentValidation;
using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator() 
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

            RuleFor(b => b.PublicationYear)
                .GreaterThan(0)
                .WithMessage("The publication year is not aceptable");

        }
    }
}
