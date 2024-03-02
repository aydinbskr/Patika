using FluentValidation;
using WebAPI.BookOperations.CreateBook;

namespace WebAPI.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(book => book.Model.GenreId).GreaterThan(0);
            RuleFor(book => book.Model.PageCount).GreaterThan(0);
            RuleFor(book => book.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now);
            RuleFor(book => book.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
