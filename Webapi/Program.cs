using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using DAL.EntityFramework.Context;
using DAL.EntityFramework.Repository;
using BLL;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes("MySuperSecretKeyForJWT2024!ExtraLongKey123");

// Laad de appsettings.json en omgevingsspecifieke configuratiebestanden
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
					 .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Voeg andere configuratiebronnen toe (indien nodig)
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];
var serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));

// Configure DbContext with Scoped Lifespan
builder.Services.AddDbContext<FitnesslybackupContext>(dbContextOptions =>
	dbContextOptions.UseMySql(connectionString, serverVersion), ServiceLifetime.Scoped);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<FitnesslybackupContext>()
	.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	options.RequireHttpsMetadata = false;
	options.SaveToken = true;
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = "https://localhost:7187",
		ValidAudience = "https://localhost:7187",
		IssuerSigningKey = new SymmetricSecurityKey(key)
	};
});

builder.Services.AddScoped<IAccountData, AccountData>();
builder.Services.AddScoped<IWorkoutData, WorkoutData>();

builder.Services.AddScoped<WorkoutService>();
builder.Services.AddScoped<AccountService>();

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

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowLocalhost");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
