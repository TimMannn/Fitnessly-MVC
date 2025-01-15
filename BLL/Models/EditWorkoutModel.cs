using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
	public class EditWorkoutModel
	{
		public int WorkoutId { get; set; }
		public string WorkoutName { get; set; }
		public string UserId { get; set; }
	}
}
