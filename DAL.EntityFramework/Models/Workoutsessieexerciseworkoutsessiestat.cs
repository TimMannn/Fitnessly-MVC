using System;
using System.Collections.Generic;

namespace DAL.EntityFramework.Models;

public partial class Workoutsessieexerciseworkoutsessiestat
{
    public int Id { get; set; }

    public int WorkoutsessieexerciseId { get; set; }

    public int WorkoutsessiestatsId { get; set; }

    public virtual Workoutsessieexercise Workoutsessieexercise { get; set; } = null!;

    public virtual Workoutsessiestat Workoutsessiestats { get; set; } = null!;
}
