using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DAL.EntityFramework.Models;

public partial class Workout
{
    public int WorkoutId { get; set; }

    public string WorkoutName { get; set; } = null!;

	public string UserId { get; set; }
	public IdentityUser User { get; set; }

	public virtual ICollection<Workoutexercise> Workoutexercises { get; set; } = new List<Workoutexercise>();
}
