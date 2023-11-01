using RealShop.Data.Data;
using RealShop.Api.Extentions;
using RealShop.Services.Mappers;
using Microsoft.EntityFrameworkCore;
using RealShop.Services.Helpers;
using RealShop.Api.MiddleWares;

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

WebEnvironmentHost.rootPath = Path.GetFullPath("wwwroot");
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
