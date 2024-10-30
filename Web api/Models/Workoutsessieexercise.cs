using System;
using System.Collections.Generic;

namespace Web_api.Models;

public partial class Workoutsessieexercise
{
    public int WorkoutsessieexerciseId { get; set; }

    public string WorkoutsessieexerciseName { get; set; } = null!;

    public int WorkoutsessieexerciseSets { get; set; }

    public virtual ICollection<Workoutsessieexerciseworkoutsessiestat> Workoutsessieexerciseworkoutsessiestats { get; set; } = new List<Workoutsessieexerciseworkoutsessiestat>();

    public virtual ICollection<Workoutsessieworkoutsessieexercise> Workoutsessieworkoutsessieexercises { get; set; } = new List<Workoutsessieworkoutsessieexercise>();
}
