using System;
using System.Collections.Generic;

namespace Fitnessly_MVC.sakila;

public partial class Workoutsessie
{
    public int WorkoutsessieId { get; set; }

    public string WorkoutsessieName { get; set; } = null!;

    public TimeOnly WorkoutsessieTijd { get; set; }

    public virtual ICollection<Workoutsessieworkoutsessieexercise> Workoutsessieworkoutsessieexercises { get; set; } = new List<Workoutsessieworkoutsessieexercise>();
}
