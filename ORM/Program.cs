using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using ORM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration["ConnectionString"];

var serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));

builder.Services.AddDbContext<WorkoutContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
