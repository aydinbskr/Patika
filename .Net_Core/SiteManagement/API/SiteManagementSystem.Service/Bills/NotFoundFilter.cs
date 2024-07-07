using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SiteManagementSystem.Repository.Bills;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Bills
{
    public class NotFoundFilter(IBillRepository BillRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;


            var BillIdFromAction = context.ActionArguments.Values.First()!;
            int BillId = 0;


            if (BillId == 0 && !int.TryParse(BillIdFromAction.ToString(), out BillId))
            {
                return;
            }

            var hasBill = BillRepository.HasExist(BillId).Result;

            if (!hasBill)
            {
                var errorMessage = $"There is no Bill with id: {BillId}";

                var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
