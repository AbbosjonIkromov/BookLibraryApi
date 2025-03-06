using System.Data;
using BookHub.WebApi.Dtos;
using BookHub.WebApi.Entities.Enums;
using FluentValidation;

namespace BookHub.WebApi.Validation
{
    public class CreateBookDtoValidation : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidation()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(r => r.Author)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.ISBN)
                .NotEmpty()
                .Length(13);

            RuleFor(r => r.PublishedYear)
                .NotEmpty()
                .InclusiveBetween(1900, 2100);

            RuleFor(r => r.Genre)
                .IsInEnum();

            RuleFor(r => r.Price)
                .NotEmpty()
                .GreaterThan(0);


        }
    }
}
