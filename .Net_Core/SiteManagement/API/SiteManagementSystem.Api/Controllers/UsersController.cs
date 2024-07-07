using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagementSystem.Api.Filters;
using SiteManagementSystem.Service.Users;
using SiteManagementSystem.Service.Users.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Users.AsyncMethods;
using SiteManagementSystem.Service.Users.DTOs;

namespace SiteManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService UserService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await UserService.GetAll());
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{UserId:int}")]
        public async Task<IActionResult> GetById(int UserId)
        {
            return CreateActionResult(await UserService.GetById(UserId));
        }


        [HttpGet("page/{page:int}/pagesize/{pageSize:max(50)}")]
        public async Task<IActionResult> GetAllByPage(int page, int pageSize)
        {
            return CreateActionResult(
                await UserService.GetAllByPage(page, pageSize));
        }




        [SendSmsWhenExceptionFilter]
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateRequestDto request)
        {

            var result = await UserService.Create(request);

            return CreateActionResult(result, nameof(GetById), new { UserId = result.Data });
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpPut("{UserId:int}")]
        public async Task<IActionResult> Update(int UserId, UserUpdateRequestDto request)
        {
            return CreateActionResult(await UserService.Update(UserId, request));
        }





        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{UserId:int}")]
        public async Task<IActionResult> Delete(int UserId)
        {
            return CreateActionResult(await UserService.Delete(UserId));
        }
    }
}
