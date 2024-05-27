using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace UnitTestFitnessly
{
    public class WorkoutDataTest : IWorkoutData
    {
        public List<Workout> GetWorkouts()
        {
            return new List<Workout>();
        }

        public void SendWorkoutsData(string workoutName)
        {
            
        }

        public void DeleteWorkouts(int ID)
        {
            
        }

        public void EditWorkouts(string NewWorkoutName, int ID)
        {

        }

        public Workout GetWorkout(int WorkoutID)
        {
            return new Workout(0, "");
        }
    }
}
