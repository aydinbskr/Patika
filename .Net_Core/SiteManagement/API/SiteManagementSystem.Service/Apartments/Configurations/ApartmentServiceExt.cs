using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SiteManagementSystem.Repository.Apartments;
using SiteManagementSystem.Service.Apartments.ApatmentCreateUseCase;
using SiteManagementSystem.Service.Apartments.AsyncMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Apartments.Configurations
{
    public static class ApartmentServiceExt
    {
        public static void AddApartmentService(this IServiceCollection services)
        {
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            services.AddValidatorsFromAssemblyContaining<ApartmentCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
