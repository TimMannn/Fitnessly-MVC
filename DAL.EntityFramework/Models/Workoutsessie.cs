using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EntityFramework.Models;

public partial class Workoutsessie
{
	[Column("workoutsessie_id")]
	public int WorkoutsessieId { get; set; }

	[Column("workoutsessie_name")]
	public string WorkoutsessieName { get; set; } = null!;

	[Column("workoutsessie_tijd")]
	public TimeOnly WorkoutsessieTijd { get; set; }

    public virtual ICollection<Workoutsessieworkoutsessieexercise> Workoutsessieworkoutsessieexercises { get; set; } = new List<Workoutsessieworkoutsessieexercise>();
}
