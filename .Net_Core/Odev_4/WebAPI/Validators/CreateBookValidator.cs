using FluentValidation;
using WebAPI.Application.BookOperations.Commands;

namespace WebAPI.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(book => book.Model.GenreId).GreaterThan(0);
            RuleFor(book => book.Model.PageCount).GreaterThan(0);
            RuleFor(book => book.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(book => book.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
