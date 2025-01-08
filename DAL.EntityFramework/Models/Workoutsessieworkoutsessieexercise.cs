using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EntityFramework.Models;

public partial class Workoutsessieworkoutsessieexercise
{
	[Column("id")]
	public int Id { get; set; }

	[Column("workoutsessie_id")]
	public int WorkoutsessieId { get; set; }

	[Column("workoutsessieexercise_id")]
	public int WorkoutsessieexerciseId { get; set; }

	public virtual Workoutsessie Workoutsessie { get; set; } = null!;
	public virtual Workoutsessieexercise Workoutsessieexercise { get; set; } = null!;
}

