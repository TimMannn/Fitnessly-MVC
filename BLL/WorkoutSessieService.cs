using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
	public class WorkoutSessieService
	{
		private readonly IWorkoutSessieData _data;

		public WorkoutSessieService(IWorkoutSessieData data)
		{
			_data = data;
		}

		public async Task<int> CreateWorkoutSessie(int workoutID)
		{
			return await _data.CreateWorkoutSessie(workoutID);
		}

		public async Task<int> CreateWorkoutSessieExercise(int workoutSessieID, string workoutSessieExerciseName, int workoutSessieStatsSets)
		{
			return await _data.CreateWorkoutSessieExercise(workoutSessieID, workoutSessieExerciseName, workoutSessieStatsSets);
		}

		public async Task<int> CreateWorkoutSessieStats(int workoutSessieExerciseID, double workoutSessieStatsGewicht, int workoutSessieStatsReps)
		{
			return await _data.CreateWorkoutSessieStats(workoutSessieExerciseID, workoutSessieStatsGewicht, workoutSessieStatsReps);
		}

		public async Task<(List<WorkoutSessieExerciseResult>, List<WorkoutSessieExerciseStats>)> GetResults(int workoutSessieID)
		{
			return await _data.GetResults(workoutSessieID);
		}
	}
}
