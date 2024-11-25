using NEWPROJECT.Services;
using NEWPROJECT.Middlewares;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
app.UseStaticFiles(); 
app.UseDefaultFiles();
app.UseHttpsRedirection();


// app.UseOurLog();
// app.Use(async (c, n) => 
// {
//     await c.Response.WriteAsync("My 3rd Middleware start\n");
//     await n();
//     await c.Response.WriteAsync("My 3rd Middleware end\n");
// });
// app.Use(async (context, next) => 
// {
//     await context.Response.WriteAsync("My 4th Middleware start\n");
//     await next();
//     await context.Response.WriteAsync("My 4th Middleware end\n");
// });
// app.UseOur5th();
// app.Run(async context => await context.Response.WriteAsync("My terminal Middleware\n"));


app.UseAuthorization();



app.MapControllers();

app.Run();
