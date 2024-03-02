using FluentValidation;
using WebAPI.BookOperations.GetBookDetail;

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
