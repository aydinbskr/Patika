using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Api.Filters;
using SiteManagementSystem.Service.Bills;
using SiteManagementSystem.Service.Bills.AsyncMethods;
using SiteManagementSystem.Service.Bills.BillCreateUseCase;
using SiteManagementSystem.Service.Bills.DTOs;

namespace SiteManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController(IBillService BillService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await BillService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{BillId:int}")]
        public async Task<IActionResult> GetById(int BillId)
        {
            return CreateActionResult(await BillService.GetById(BillId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await BillService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(BillCreateRequestDto request)
        {

            var result = await BillService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { BillId = result.Data });
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{BillId:int}")]
        public async Task<IActionResult> Update(int BillId, BillUpdateRequestDto request)
        {
            return CreateActionResult(await BillService.Update(BillId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{BillId:int}")]
        public async Task<IActionResult> Delete(int BillId)
        {
            return CreateActionResult(await BillService.Delete(BillId));
        }
    }
}
