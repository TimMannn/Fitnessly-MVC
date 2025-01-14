using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Moq;

namespace UnitTestFitnessly
{
    public class WorkoutDataTest : IWorkoutData
    {
        public async Task<List<WorkoutDetails>> GetWorkouts(string userId)
        {
            return new List<WorkoutDetails>();
        }

        public async Task SendWorkoutsData(string workoutName, string userId)
        {
            
        }

        public async Task DeleteWorkouts(int ID)
        {
            
        }

        public async Task EditWorkouts(string NewWorkoutName, int ID, string userId)
        {

        }

        public async Task<WorkoutDetails> GetWorkout(int WorkoutID)
        {
			var exercise = new WorkoutDetails(0, "", "");
			return await Task.FromResult(exercise);

        }
    }
}