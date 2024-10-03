using System;
using System.Collections.Generic;

namespace Fitnessly_MVC.sakila;

public partial class Workout
{
    public int WorkoutId { get; set; }

    public string WorkoutName { get; set; } = null!;

    public virtual ICollection<Workoutexercise> Workoutexercises { get; set; } = new List<Workoutexercise>();
}
