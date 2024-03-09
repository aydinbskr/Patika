using FluentValidation;
using WebAPI.Application.BookOperations.Queries;

namespace WebAPI.Validators
{
    public class GetBookValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookValidator()
        {
            RuleFor(book => book.BookId).GreaterThan(0);
            
        }
    }
}
