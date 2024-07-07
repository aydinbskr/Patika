using SiteManagementSystem.Service.Users.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Users.DTOs;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users.AsyncMethods
{
    public interface IUserService
    {
        Task<ResponseModelDto<ImmutableList<UserDto>>> GetAll();


        Task<ResponseModelDto<UserDto?>> GetById(int id);

        Task<ResponseModelDto<ImmutableList<UserDto>>> GetAllByPage(int page, int pageSize);


        Task<ResponseModelDto<int>> Create(UserCreateRequestDto request);
        Task<ResponseModelDto<NoContent>> Update(int UserId, UserUpdateRequestDto request);

        


        Task<ResponseModelDto<NoContent>> Delete(int id);
    }
}
