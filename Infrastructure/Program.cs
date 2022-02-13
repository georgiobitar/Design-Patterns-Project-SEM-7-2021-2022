using Infrastructure;
using Infrastructure.DataBaseFactory;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

var connectionString = new DataBaseFactory().ChooseDbContext();
builder.Services.AddDbContext<DesignPatterns20212022_TRAFFICSIMULATORContext>(options => options.UseSqlServer(connectionString));

