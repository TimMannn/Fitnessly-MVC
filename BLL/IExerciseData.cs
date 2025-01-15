using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
	public interface IExerciseData
	{
		Task<List<ExerciseDetails>> GetExercises(int WorkoutID);

		Task SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string display, int WorkoutID);

		Task DeleteExercise(int ID);

		Task EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID);

		Task<ExerciseDetails> GetExercise(int ExerciseID);

		Task DisplayTrueExercise();
		Task DisplayFalseExercise(int ExerciseID);
	}
}
