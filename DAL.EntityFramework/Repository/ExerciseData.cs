using BLL;
using DAL.EntityFramework.Context;
using DALModels = DAL.EntityFramework.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repository
{
	public class ExerciseData : IExerciseData
	{
		private readonly FitnesslybackupContext _context;

		public ExerciseData(FitnesslybackupContext context)
		{
			_context = context;
		}

		public async Task<List<ExerciseDetails>> GetExercises(int workoutID)
		{
			return await _context.Exercises
				.Where(e => _context.Workoutexercises
					.Where(we => we.WorkoutId == workoutID)
					.Select(we => we.ExerciseId)
					.Contains(e.ExerciseId))
				.Select(e => new ExerciseDetails(e.ExerciseId, e.ExerciseName, e.ExerciseGewicht, e.ExerciseSets, e.ExerciseReps, e.ExerciseDisplay))
				.ToListAsync();
		}

		public async Task SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string display, int workoutID)
		{
			using (var transaction = await _context.Database.BeginTransactionAsync())
			{
				try
				{
					var exercise = new DALModels.Exercise
					{
						ExerciseName = exerciseName,
						ExerciseGewicht = exerciseGewicht,
						ExerciseSets = exerciseSets,
						ExerciseReps = exerciseReps,
						ExerciseDisplay = display
					};
					_context.Exercises.Add(exercise);
					await _context.SaveChangesAsync();

					var workoutexercise = new DALModels.Workoutexercise
					{
						WorkoutId = workoutID,
						ExerciseId = exercise.ExerciseId
					};
					_context.Workoutexercises.Add(workoutexercise);
					await _context.SaveChangesAsync();

					await transaction.CommitAsync();
				}
				catch
				{
					await transaction.RollbackAsync();
					throw;
				}
			}
		}

		public async Task DeleteExercise(int ID)
		{
			using (var transaction = await _context.Database.BeginTransactionAsync())
			{
				try
				{
					var exercise = await _context.Exercises.FindAsync(ID);
					if (exercise != null)
					{
						_context.Exercises.Remove(exercise);
						await _context.SaveChangesAsync();
					}

					var workoutexercises = _context.Workoutexercises.Where(we => we.ExerciseId == ID);
					_context.Workoutexercises.RemoveRange(workoutexercises);
					await _context.SaveChangesAsync();

					await transaction.CommitAsync();
				}
				catch
				{
					await transaction.RollbackAsync();
					throw;
				}
			}
		}

		public async Task EditExercise(string newExerciseName, double newExerciseGewicht, int newExerciseSets, int newExerciseReps, int exerciseID)
		{
			var exercise = await _context.Exercises.FindAsync(exerciseID);
			if (exercise != null)
			{
				exercise.ExerciseName = newExerciseName;
				exercise.ExerciseGewicht = newExerciseGewicht;
				exercise.ExerciseSets = newExerciseSets;
				exercise.ExerciseReps = newExerciseReps;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<ExerciseDetails> GetExercise(int exerciseID)
		{
			var exercise = await _context.Exercises
				.Where(e => e.ExerciseId == exerciseID)
				.Select(e => new ExerciseDetails(e.ExerciseId, e.ExerciseName, e.ExerciseGewicht, e.ExerciseSets, e.ExerciseReps, e.ExerciseDisplay))
				.FirstOrDefaultAsync();

			return exercise ?? new ExerciseDetails(0, "", 0, 0, 0, "block");
		}

		public async Task DisplayTrueExercise()
		{
			var exercises = await _context.Exercises.ToListAsync();
			exercises.ForEach(e => e.ExerciseDisplay = "block");
			await _context.SaveChangesAsync();
		}

		public async Task DisplayFalseExercise(int exerciseID)
		{
			var exercise = await _context.Exercises.FindAsync(exerciseID);
			if (exercise != null)
			{
				exercise.ExerciseDisplay = "none";
				await _context.SaveChangesAsync();
			}
		}
	}
}
