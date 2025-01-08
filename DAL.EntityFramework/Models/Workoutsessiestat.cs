using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EntityFramework.Models;

public partial class Workoutsessiestat
{
	[Column("workoutsessiestats_id")]
	public int WorkoutsessiestatsId { get; set; }

	[Column("workoutsessiestats_gewicht")]
	public double WorkoutsessiestatsGewicht { get; set; }

	[Column("workoutsessiestats_reps")]
	public int WorkoutsessiestatsReps { get; set; }

	public virtual ICollection<Workoutsessieexerciseworkoutsessiestat> Workoutsessieexerciseworkoutsessiestats { get; set; } = new List<Workoutsessieexerciseworkoutsessiestat>();
}

