using Infrastructure;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<DesignPatterns20212022_TRAFFICSIMULATORContext>();
builder.Services.AddDbContext<DesignPatterns20212022_TRAFFICSIMULATORContext>(options => options.UseSqlServer("Name=DesignDatabase"));
builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddTransient<ILoginService, LoginService>();
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
