using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Taxi_Managment_System_DAL.Data;
using Taxi_Managment_System_DAL.Generic;
using Taxi_Managment_System_DAL.Generic.Interfaces;
using Taxi_Managment_System_DAL.UnitOfWork;
using Taxi_Managment_System_DAL.UnitOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "The swagger!",
        Description = "The swagger in Program.cs!"
    });
});


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnect"));

});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<>();


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
