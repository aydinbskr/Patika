using FluentValidation;
using WebAPI.Application.AuthorOperations.Commands;

namespace WebAPI.Validators.AuthorValidators
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(book => book.Model.Name).NotEmpty();
            RuleFor(book => book.Model.Surname).NotEmpty();

        }
    }
}
