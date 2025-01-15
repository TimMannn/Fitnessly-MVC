using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	public class AddExerciseModel
	{
		public string ExerciseName { get; set; }
		public double ExerciseGewicht { get; set; }
		public int ExerciseSets { get; set; }
		public int ExerciseReps { get; set; }
		public string Display { get; set; }
		public int WorkoutID { get; set; }
	}
}
