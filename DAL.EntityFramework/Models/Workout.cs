namespace DAL.EntityFramework.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }

        public string WorkoutName { get; set; } = null!;

        public virtual ICollection<Workoutexercise> Workoutexercises { get; set; } = new List<Workoutexercise>();
    }
}
