using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class WorkoutSessieExerciseResult(string name, int sets)
    {
        public string Name { get; } = name;
        public int Sets { get; } = sets;
    }
}
