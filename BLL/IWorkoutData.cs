using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IWorkoutData
    {
        List<Workout> GetWorkouts();
        void SendWorkoutsData(string workoutName);
        void DeleteWorkouts(int ID);
        void EditWorkouts(string NewWorkoutName, int WorkoutID);
        Workout GetWorkout(int ID);
    }
}
