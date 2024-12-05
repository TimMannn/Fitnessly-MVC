using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IWorkoutData
    {
        Task<List<WorkoutDetails>> GetWorkouts(string userId);
        Task SendWorkoutsData(string workoutName, string userId);
        Task DeleteWorkouts(int ID);
        Task EditWorkouts(string NewWorkoutName, int WorkoutID);
        Task<WorkoutDetails> GetWorkout(int ID);
    }
}
