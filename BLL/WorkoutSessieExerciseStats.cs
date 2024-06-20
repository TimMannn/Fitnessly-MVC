using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class WorkoutSessieExerciseStats(double gewicht, int reps)
    {
        public double Gewicht { get; } = gewicht;
        public int Reps { get; } = reps;
    }
}
