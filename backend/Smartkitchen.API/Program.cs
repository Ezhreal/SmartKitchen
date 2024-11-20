using Microsoft.EntityFrameworkCore;
using Smartkitchen.API.Data;
using FluentValidation;
using Smartkitchen.API.DTO.Users;
using Smartkitchen.API.Models;
using Smartkitchen.API.Validators;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Registrar o contexto do banco de dados
builder.Services.AddDbContext<SmartKitchenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SmartKitchen")));

builder.Services.AddTransient<IValidator<UserBase>, UserValidatorBase<UserBase>>();
builder.Services.AddTransient<IValidator<User>, UserValidator>();
builder.Services.AddTransient<IValidator<UserDTO>, UserDTOValidator>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
