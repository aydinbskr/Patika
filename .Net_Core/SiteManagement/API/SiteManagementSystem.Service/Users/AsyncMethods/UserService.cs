using AutoMapper;
using SiteManagementSystem.Repository;
using SiteManagementSystem.Repository.Users;
using SiteManagementSystem.Service.Users.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Users.DTOs;
using SiteManagementSystem.Service.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users.AsyncMethods
{

    public class UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork, IMapper mapper)
         : IUserService
    {
        public async Task<ResponseModelDto<int>> Create(UserCreateRequestDto request)
        {
            var newUser = new User
            {
               FullName = request.FullName,
               NationalId = request.NationalId,
               Email = request.Email,
               Phone = request.Phone,
               UserType = request.UserType
            };

            await UserRepository.Create(newUser);
            await unitOfWork.CommitAsync();

            return ResponseModelDto<int>.Success(newUser.Id, HttpStatusCode.Created);
        }

        public async Task<ResponseModelDto<NoContent>> Delete(int id)
        {
            await UserRepository.Delete(id);
            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseModelDto<ImmutableList<UserDto>>> GetAllByPage(int page, int pageSize)
        {
            var UsersList = await UserRepository.GetAllByPage(page, pageSize);


            var UserListAsDto = mapper.Map<List<UserDto>>(UsersList);

            return ResponseModelDto<ImmutableList<UserDto>>.Success(UserListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<ImmutableList<UserDto>>> GetAll(
            )
        {
            var UserList = await UserRepository.GetAll();

            var UserListAsDto = mapper.Map<List<UserDto>>(UserList);


            return ResponseModelDto<ImmutableList<UserDto>>.Success(UserListAsDto.ToImmutableList());
        }

        public async Task<ResponseModelDto<UserDto?>> GetById(int id)
        {
            var hasUser = await UserRepository.GetById(id);


            var UserAsDto = mapper.Map<UserDto>(hasUser);

            return ResponseModelDto<UserDto?>.Success(UserAsDto);
        }

        public async Task<ResponseModelDto<NoContent>> Update(int UserId, UserUpdateRequestDto request)
        {
            var hasUser = await UserRepository.GetById(UserId);


            hasUser.FullName = request.FullName;
            hasUser.NationalId = request.NationalId;
            hasUser.Email = request.Email;
            hasUser.Phone = request.Phone;
            hasUser.UserType = request.UserType;
           


            await UserRepository.Update(hasUser);


            await unitOfWork.CommitAsync();
            return ResponseModelDto<NoContent>.Success(HttpStatusCode.NoContent);
        }

      


    }
}
