using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SiteManagementSystem.Repository.Bills;
using SiteManagementSystem.Service.Bills.AsyncMethods;
using SiteManagementSystem.Service.Bills.BillCreateUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Service.Bills.Configurations
{
    public static class BillServiceExt
    {
        public static void AddBillService(this IServiceCollection services)
        {
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBillRepository, BillRepository>();

            services.AddValidatorsFromAssemblyContaining<BillCreateRequestValidator>();
            services.AddScoped<NotFoundFilter>();
        }
    }
}
