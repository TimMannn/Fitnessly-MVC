using System;
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
			Console.WriteLine($"Fetching results for workoutSessieID: {workoutSessieID}");
			var results = await _data.GetResults(workoutSessieID);
			Console.WriteLine("Fetched results:");

			Console.WriteLine("WorkoutSessieExerciseResults:");
			foreach (var result in results.Item1)
			{
				Console.WriteLine($"Name: {result.Name}, Sets: {result.Sets}");
			}

			Console.WriteLine("WorkoutSessieExerciseStats:");
			foreach (var stat in results.Item2)
			{
				Console.WriteLine($"Gewicht: {stat.Gewicht}, Reps: {stat.Reps}");
			}

			return results;
		}
	}
}
