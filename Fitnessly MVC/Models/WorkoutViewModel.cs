using BLL;

namespace Fitnessly_MVC.Models
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
