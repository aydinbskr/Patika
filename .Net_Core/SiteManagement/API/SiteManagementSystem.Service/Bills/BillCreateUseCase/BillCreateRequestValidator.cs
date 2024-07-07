using FluentValidation;
using SiteManagementSystem.Repository.Bills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Bills.BillCreateUseCase
{
    public class BillCreateRequestValidator : AbstractValidator<BillCreateRequestDto>
    {
        public BillCreateRequestValidator(IBillRepository BillRepository)
        {
            RuleFor(x => x.ApartmentId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Amount)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Type)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.IsPaid)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");






        }
    }
}
