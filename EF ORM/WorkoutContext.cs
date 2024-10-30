using Fitnessly_MVC.sakila;
using Microsoft.EntityFrameworkCore;
using Web_api.Models;

public class WorkoutContext : DbContext
{
    public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
    {

    }

    public DbSet<Fitnessly_MVC.sakila.Workout> Workouts { get; set; }
}