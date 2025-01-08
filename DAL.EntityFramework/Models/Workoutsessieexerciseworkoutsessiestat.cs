using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EntityFramework.Models;

public partial class Workoutsessieexerciseworkoutsessiestat
{
	[Column("id")]
	public int Id { get; set; }

	[Column("workoutsessieexercise_id")]
	public int WorkoutsessieexerciseId { get; set; }

	[Column("workoutsessiestats_id")]
	public int WorkoutsessiestatsId { get; set; }

	public virtual Workoutsessieexercise Workoutsessieexercise { get; set; } = null!;
	public virtual Workoutsessiestat Workoutsessiestats { get; set; } = null!;
}

