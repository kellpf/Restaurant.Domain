using Domain.Restaurants;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Restaurants;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Service
builder.Services.AddDbContext<RestaurantDbContext>(opt => opt.UseSqlServer(
    configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebAPI")));


builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

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
