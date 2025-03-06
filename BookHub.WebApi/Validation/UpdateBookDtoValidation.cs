using BookHub.WebApi.Dtos;
using FluentValidation;

namespace BookHub.WebApi.Validation
{
    public class UpdateBookDtoValidation : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidation()
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
