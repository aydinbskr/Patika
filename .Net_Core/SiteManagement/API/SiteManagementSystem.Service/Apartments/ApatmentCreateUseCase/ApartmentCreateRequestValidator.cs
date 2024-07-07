using FluentValidation;
using SiteManagementSystem.Repository.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Apartments.ApatmentCreateUseCase
{
    public class ApartmentCreateRequestValidator : AbstractValidator<ApartmentCreateRequestDto>
    {
        public ApartmentCreateRequestValidator(IApartmentRepository ApartmentRepository)
        {
            RuleFor(x => x.Block)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Status)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Type)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.OwnerOrTenant)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");






        }
    }
}
