using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteManagementSystem.Api.Filters;
using SiteManagementSystem.Repository;
using SiteManagementSystem.Service;
using SiteManagementSystem.Service.Apartments.Configurations;
using SiteManagementSystem.Service.Bills.Configurations;
using SiteManagementSystem.Service.Users.Configurations;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"),
        x => { x.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.GetName().Name); });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ServiceAssembly).Assembly);

builder.Services.AddControllers(x => x.Filters.Add<ValidationFilter>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddApartmentService();

builder.Services.AddUserService();

builder.Services.AddBillService();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
