using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL;

namespace UnitTestFitnessly
{
	public class ExerciseDataTest : IExerciseData
	{
		public async Task<List<ExerciseDetails>> GetExercises(int WorkoutID)
		{
			// Simuleer een asynchrone actie met een lege lijst
			return await Task.FromResult(new List<ExerciseDetails>());
		}

		public Task SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string display, int WorkoutID)
		{
			// Simuleer een voltooide taak
			return Task.CompletedTask;
		}

		public Task DeleteExercise(int ID)
		{
			// Simuleer een voltooide taak
			return Task.CompletedTask;
		}

		public Task EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID)
		{
			// Simuleer een voltooide taak
			return Task.CompletedTask;
		}

		public async Task<ExerciseDetails> GetExercise(int ExerciseID)
		{
			// Simuleer een oefening detail ophalen
			var exercise = new ExerciseDetails(0, "", 0, 0, 0, "none");
			return await Task.FromResult(exercise);
		}

		public Task DisplayTrueExercise()
		{
			// Simuleer een voltooide taak
			return Task.CompletedTask;
		}

		public Task DisplayFalseExercise(int ExerciseID)
		{
			// Simuleer een voltooide taak
			return Task.CompletedTask;
		}
	}
}
