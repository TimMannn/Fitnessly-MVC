using BLL;
using DAL.EntityFramework;
using DAL.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration["ConnectionString"];

//var serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));

/*builder.Services.AddDbContext<WorkoutContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)); */

builder.Services.AddScoped<IWorkoutData, WorkoutData>();
builder.Services.AddScoped<IExerciseData, ExerciseData>();
builder.Services.AddScoped<IWorkoutSessieData, WorkoutSessieData>();

builder.Services.AddScoped<WorkoutService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<WorkoutSessieService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
