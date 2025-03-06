using System.Data;
using BookHub.WebApi.Dtos;
using BookHub.WebApi.Entities.Enums;
using BookHub.WebApi.Services.Contracts;
using FluentValidation;

namespace BookHub.WebApi.Validation
{
    public class CreateBookDtoValidation : AbstractValidator<CreateBookDto>
    {
        private readonly IBookService _bookService;
        public CreateBookDtoValidation(IBookService bookService)
        {
            _bookService = bookService;

            RuleFor(r => r.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(r => r.Author)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.ISBN)
                .NotEmpty()
                .Length(13)
                .Must(IsValidIsbn)
                .WithMessage("ISBN already exists.");

            RuleFor(r => r.PublishedYear)
                .NotEmpty()
                .InclusiveBetween(1900, 2100);

            RuleFor(r => r.Genre)
                .IsInEnum();

            RuleFor(r => r.Price)
                .NotEmpty()
                .GreaterThan(0);

        }

        private bool IsValidIsbn(string isbn)
        {
            return !_bookService.GetAll()
                .Any(r => r.ISBN.Equals(isbn));
        }
    }
}
