using System;
using System.Collections.Generic;

namespace Web_api.Models;

public partial class Workoutsessieworkoutsessieexercise
{
    public int Id { get; set; }

    public int WorkoutsessieId { get; set; }

    public int WorkoutsessieexerciseId { get; set; }

    public virtual Workoutsessie Workoutsessie { get; set; } = null!;

    public virtual Workoutsessieexercise Workoutsessieexercise { get; set; } = null!;
}
