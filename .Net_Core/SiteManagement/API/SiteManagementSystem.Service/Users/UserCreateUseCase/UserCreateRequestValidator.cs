using FluentValidation;
using SiteManagementSystem.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users.ApatmentCreateUseCase
{
    public class UserCreateRequestValidator : AbstractValidator<UserCreateRequestDto>
    {
        public UserCreateRequestValidator(IUserRepository UserRepository)
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.NationalId)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Email)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.UserType)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull().WithMessage("{PropertyName} is required");






        }
    }
}
