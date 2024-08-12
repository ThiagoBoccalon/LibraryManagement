using LibraryManagement.API.Controllers;
using LibraryManagement.API.Models;
using LibraryManagement.Application.Commands.BookCommands.CreateBook;
using LibraryManagement.Application.Services.Implementations;
using LibraryManagement.Application.Services.Interfaces;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using LibraryManagement.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration;
builder.Services.Configure<OpeningTimeOption>(config.GetSection("OpeningTime"));

var connectionString = builder.Configuration.GetConnectionString("LibraryManagementCs");
builder.Services.AddDbContext<LibraryManagementDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateBookCommand));

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
