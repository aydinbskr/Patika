using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SiteManagementSystem.Repository.Users;
using SiteManagementSystem.Service.Users.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Users.AsyncMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Users.Configurations
{
    public static class UserServiceExt
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddValidatorsFromAssemblyContaining<UserCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
