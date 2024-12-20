using Application;
using Data.SqlServer;
using Microsoft.Extensions.Configuration;
using Repository;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbServices(Configuration);
var p = builder.Services.AddRepositoryServices();
var q = builder.Services.AddApplicationServices();
builder.Services.AddMediatR(ctg => ctg.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjector).Assembly));

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
