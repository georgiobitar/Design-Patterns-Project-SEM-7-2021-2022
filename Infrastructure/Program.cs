using Infrastructure;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

builder.Services.AddTransient<DesignPatterns20212022_TRAFFICSIMULATORContext>();
