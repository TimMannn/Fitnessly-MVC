using BLL;

namespace Fitnessly_MVC.Models
{
    public class SetModel
    {
        public double Gewicht { get; set; }
        public int Reps { get; set; }
    }

    public class WorkoutSessieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SetModel> SetsModels { get; set; }
        public int Sets { get; set; }
        public double Gewicht { get; set; }
        public int Reps { get; set; }
        public List<Exercise> Exercises { get; set; }
        public int WorkoutID { get; set; }
    }
}
