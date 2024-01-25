using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceAPI.Common;
using ServiceAPI.Common.Mvc;
using ServiceAPI.Common.Ratelimit;
using ServiceAPI.UnitOfWorks;
using ServiceAPI.v1.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRateLimit();
builder.Services.AddCorsStar();
//Database
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<LibraryDbContext>(
               x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRateLimiter();
app.UseErrorHandler();
app.UseHttpsRedirection();
app.UseCorsStar();
app.MapControllers();
app.Run();
