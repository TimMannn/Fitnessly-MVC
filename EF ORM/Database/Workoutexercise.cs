using System;
using System.Collections.Generic;

namespace Fitnessly_MVC.sakila;

public partial class Workoutexercise
{
    public int Id { get; set; }

    public int WorkoutId { get; set; }

    public int ExerciseId { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Workout Workout { get; set; } = null!;
}
