using FluentValidation;
using WebAPI.Application.AuthorOperations.Commands;
using WebAPI.Application.BookOperations.Commands;

namespace WebAPI.Validators.AuthorValidators
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(book => book.Model.Name).NotEmpty();
            RuleFor(book => book.Model.Surname).NotEmpty();
            
        }
    }
}
