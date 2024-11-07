using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExerciseDetails(int id, string name, double gewicht, int sets, int reps, string display)
    {
        public int Id { get; } = id;

        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get;  } = name;
        public double Gewicht { get; } = gewicht;
        public int Sets { get; } = sets;
        public int Reps { get; } = reps;
        public string Display { get; } = display;
    }
}
