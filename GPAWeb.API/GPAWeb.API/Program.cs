using GPAWeb.BLL;
using GPAWeb.DAL;
using GPAWeb.DAL.DataContext;
using GPAWeb.DAL.Infrastructure;
using GPAWeb.DAL.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GPADbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GPADbConnection")));
builder.Services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

DALDependencies.RegisterDALDependencies(builder.Services, builder.Configuration);
BLLDependencies.RegisterBLLDependencies(builder.Services, builder.Configuration);


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
