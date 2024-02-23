using DataBaseConnection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using Services.Interfaces;
using Services.Services;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get the connection string from the environment variable
var connectionString = builder.Configuration.GetConnectionString("CodepenAIConnection");

// Set the MySQL Server Version
var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

// Configure the DbContext with the connection string
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<DataContext>();

//Connect IDataService to DataService
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IProjectsService, ProjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/logout", async (SignInManager<User> signInManager,
    [FromBody] object empty) =>
{
    if (empty != null)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
    return Results.Unauthorized();
})
.RequireAuthorization();

app.MapIdentityApi<User>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
