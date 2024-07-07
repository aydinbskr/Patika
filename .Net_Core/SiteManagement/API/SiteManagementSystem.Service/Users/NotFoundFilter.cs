using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SiteManagementSystem.Repository.Users;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users
{
    public class NotFoundFilter(IUserRepository UserRepository) : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;


            var UserIdFromAction = context.ActionArguments.Values.First()!;
            int UserId = 0;


            if (UserId == 0 && !int.TryParse(UserIdFromAction.ToString(), out UserId))
            {
                return;
            }

            var hasUser = UserRepository.HasExist(UserId).Result;

            if (!hasUser)
            {
                var errorMessage = $"There is no User with id: {UserId}";

                var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }


        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
