using FluentValidation;
using WebAPI.Application.BookOperations.Commands;

namespace WebAPI.Validators
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(book => book.BookId).GreaterThan(0);
            
        }
    }
}
