using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Exercise(int id, string name, double gewicht, int sets, int reps)
    {
        public int Id { get; set; } = id;

        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = name;
        public double Gewicht { get; set;} = gewicht;
        public int Sets { get; set; } = sets;
        public int Reps { get; set; } = reps;
    }
}
