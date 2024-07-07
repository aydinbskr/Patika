using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SiteManagementSystem.Service.SharedDTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiteManagementSystem.Api.Filters
{
    public class SendSmsWhenExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = false;

            Console.WriteLine($"Hata var. Sms gönderildi : {context.Exception.Message}");

            var responseModel = ResponseModelDto<NoContent>.Fail(context.Exception.Message);

            context.Result = new BadRequestObjectResult(responseModel);
        }
    }
}
