using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EntityFramework.Models;


public partial class Workoutsessieexercise
{
	[Column("workoutsessieexercise_id")]
	public int WorkoutsessieexerciseId { get; set; }

	[Column("workoutsessieexercise_name")]
	public string WorkoutsessieexerciseName { get; set; } = null!;

	[Column("workoutsessieexercise_sets")]
	public int WorkoutsessieexerciseSets { get; set; }

	public virtual ICollection<Workoutsessieexerciseworkoutsessiestat> Workoutsessieexerciseworkoutsessiestats { get; set; } = new List<Workoutsessieexerciseworkoutsessiestat>();

	public virtual ICollection<Workoutsessieworkoutsessieexercise> Workoutsessieworkoutsessieexercises { get; set; } = new List<Workoutsessieworkoutsessieexercise>();
}

