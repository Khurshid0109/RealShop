using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealShop.Api.Extentions;
using RealShop.Data.Data;
using RealShop.Domain.IRepository;
using RealShop.Domain.Repositories;
using RealShop.Services.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registiration of services
builder.Services.CustomExtention();
builder.Services.AddAutoMapper(typeof(MapperProfile));

//Database connection
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
