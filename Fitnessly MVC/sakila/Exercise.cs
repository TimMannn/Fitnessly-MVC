using System;
using System.Collections.Generic;

namespace Fitnessly_MVC.sakila;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public string ExerciseName { get; set; } = null!;

    public double ExerciseGewicht { get; set; }

    public int ExerciseSets { get; set; }

    public int ExerciseReps { get; set; }

    public string ExerciseDisplay { get; set; } = null!;

    public virtual ICollection<Workoutexercise> Workoutexercises { get; set; } = new List<Workoutexercise>();
}
