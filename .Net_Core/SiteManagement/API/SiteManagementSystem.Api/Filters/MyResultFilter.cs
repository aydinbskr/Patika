using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Service.SharedDTOs;
using SiteManagementSystem.Service.Apartments.DTOs;

namespace SiteManagementSystem.Api.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var responseBody = (context.Result as ObjectResult).Value;

            if (responseBody is ResponseModelDto<ApartmentDto> response)
            {

            }


            Console.WriteLine("OnResultExecuting");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("OnResultExecuted");
        }
    }
}
