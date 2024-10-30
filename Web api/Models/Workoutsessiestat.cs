using System;
using System.Collections.Generic;

namespace Web_api.Models;

public partial class Workoutsessiestat
{
    public int WorkoutsessiestatsId { get; set; }

    public double WorkoutsessiestatsGewicht { get; set; }

    public int WorkoutsessiestatsReps { get; set; }

    public virtual ICollection<Workoutsessieexerciseworkoutsessiestat> Workoutsessieexerciseworkoutsessiestats { get; set; } = new List<Workoutsessieexerciseworkoutsessiestat>();
}
