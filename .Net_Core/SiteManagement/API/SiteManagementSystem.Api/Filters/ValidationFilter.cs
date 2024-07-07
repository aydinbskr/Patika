using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Service.SharedDTOs;
using NoContent = SiteManagementSystem.Service.SharedDTOs.NoContent;

namespace SiteManagementSystem.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();


                var responseModel = ResponseModelDto<NoContent>.Fail(errors);

                context.Result = new BadRequestObjectResult(responseModel);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
