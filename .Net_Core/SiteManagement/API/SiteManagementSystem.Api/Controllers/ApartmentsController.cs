using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SiteManagementSystem.Api.Filters;
using SiteManagementSystem.Service.Apartments;
using SiteManagementSystem.Service.Apartments.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Apartments.AsyncMethods;
using SiteManagementSystem.Service.Apartments.DTOs;

namespace SiteManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController(IApartmentService apartmentService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await apartmentService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [MyResourceFilter]
        [MyActionFilter]
        [MyResultFilter]
        [HttpGet("{ApartmentId:int}")]
        public async Task<IActionResult> GetById(int ApartmentId)
        {
            return CreateActionResult(await apartmentService.GetById(ApartmentId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await apartmentService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(ApartmentCreateRequestDto request)
        {

            var result = await apartmentService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { ApartmentId = result.Data });
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{ApartmentId:int}")]
        public async Task<IActionResult> Update(int ApartmentId, ApartmentUpdateRequestDto request)
        {
            return CreateActionResult(await apartmentService.Update(ApartmentId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{ApartmentId:int}")]
        public async Task<IActionResult> Delete(int ApartmentId)
        {
            return CreateActionResult(await apartmentService.Delete(ApartmentId));
        }
    }
}
