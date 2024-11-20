using System.ComponentModel.DataAnnotations;

namespace DAL.EntityFramework.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }

		[Required(ErrorMessage = "Workout name is required")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Workout name must be between 3 and 50 characters")]
		public string WorkoutName { get; set; } = null!;

        public virtual ICollection<Workoutexercise> Workoutexercises { get; set; } = new List<Workoutexercise>();
    }
}
