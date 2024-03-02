using FluentValidation;
using WebAPI.BookOperations.DeleteBook;

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
