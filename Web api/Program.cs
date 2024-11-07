using Microsoft.EntityFrameworkCore;
using DAL.EntityFramework.Context;
using DAL.EntityFramework.Repository;
using BLL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];
var serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));
builder.Services.AddDbContext<FitnesslybackupContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion));

// Register Repositories for EntityFramework DAL
builder.Services.AddScoped<IWorkoutData, WorkoutData>();

// Register Services
builder.Services.AddScoped<WorkoutService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("https://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();
