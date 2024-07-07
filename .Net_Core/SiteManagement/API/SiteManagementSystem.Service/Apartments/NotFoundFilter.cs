using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SiteManagementSystem.Repository.Apartments;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Apartments
{
    public class NotFoundFilter(IApartmentRepository ApartmentRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;


            var ApartmentIdFromAction = context.ActionArguments.Values.First()!;
            int ApartmentId = 0;


            if (ApartmentId == 0 && !int.TryParse(ApartmentIdFromAction.ToString(), out ApartmentId))
            {
                return;
            }

            var hasApartment = ApartmentRepository.HasExist(ApartmentId).Result;

            if (!hasApartment)
            {
                var errorMessage = $"There is no Apartment with id: {ApartmentId}";

                var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
