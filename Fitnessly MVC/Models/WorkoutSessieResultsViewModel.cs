using BLL;

namespace Fitnessly_MVC.Models
{
    public class WorkoutSessieResultsViewModel
    {
        public List<WorkoutSessieExerciseResult> workoutSessieExerciseResults { get; set; }
        public List<WorkoutSessieExerciseStats> workoutSessieExerciseStats { get; set; }
    }
}
