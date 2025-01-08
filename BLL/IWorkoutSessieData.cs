using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
	public interface IWorkoutSessieData
	{
		Task<int> CreateWorkoutSessie(int workoutID);
		Task<int> CreateWorkoutSessieExercise(int workoutSessieID, string workoutSessieExerciseName, int workoutSessieStatsSets);
		Task<int> CreateWorkoutSessieStats(int workoutSessieExerciseID, double workoutSessieStatsGewicht, int workoutSessieStatsReps);
		Task<(List<WorkoutSessieExerciseResult>, List<WorkoutSessieExerciseStats>)> GetResults(int workoutSessieID);
	}
}
