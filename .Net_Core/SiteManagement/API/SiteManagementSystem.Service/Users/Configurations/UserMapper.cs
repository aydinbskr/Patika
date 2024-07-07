using AutoMapper;
using SiteManagementSystem.Repository.Users;
using SiteManagementSystem.Service.Users.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiteManagementSystem.Service.Users.Configurations
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserUpdateRequestDto>().ReverseMap();
            CreateMap<User, UserCreateRequestDto>().ReverseMap();

        }
    }
}
