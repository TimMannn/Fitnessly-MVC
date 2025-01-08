using BLL;
using DAL.EntityFramework.Context;
using DALModels = DAL.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EntityFramework.Models;

namespace DAL.EntityFramework.Repository
{
	public class WorkoutSessieData : IWorkoutSessieData
	{
		private readonly FitnesslybackupContext _context;

		public WorkoutSessieData(FitnesslybackupContext context)
		{
			_context = context;
		}

		// Maak een nieuwe WorkoutSessie
		public async Task<int> CreateWorkoutSessie(int workoutID)
		{
			var workout = await _context.Workouts.FindAsync(workoutID);
			if (workout == null) throw new KeyNotFoundException("Workout not found");

			var workoutSessie = new DALModels.Workoutsessie
			{
				WorkoutsessieName = workout.WorkoutName, 
				WorkoutsessieTijd = TimeOnly.MinValue  
			};

			_context.Workoutsessies.Add(workoutSessie);
			await _context.SaveChangesAsync();

			return workoutSessie.WorkoutsessieId; 
		}

		// Voeg een nieuwe WorkoutSessieExercise toe
		public async Task<int> CreateWorkoutSessieExercise(int workoutSessieId, string exerciseName, int sets)
		{
			var workoutSessie = await _context.Workoutsessies.FindAsync(workoutSessieId);
			if (workoutSessie == null) throw new KeyNotFoundException("WorkoutSessie not found");

			var exercise = new DALModels.Workoutsessieexercise
			{
				WorkoutsessieexerciseName = exerciseName,
				WorkoutsessieexerciseSets = sets,
				Workoutsessieworkoutsessieexercises = new List<Workoutsessieworkoutsessieexercise>
		{
			new Workoutsessieworkoutsessieexercise
			{
				WorkoutsessieId = workoutSessieId
			}
		}
			};

			_context.Workoutsessieexercises.Add(exercise);
			await _context.SaveChangesAsync();

			return exercise.WorkoutsessieexerciseId;
		}


		// Voeg een nieuwe WorkoutSessieStats toe
		public async Task<int> CreateWorkoutSessieStats(int exerciseId, double gewicht, int reps)
		{
			var exercise = await _context.Workoutsessieexercises.FindAsync(exerciseId);
			if (exercise == null) throw new KeyNotFoundException("WorkoutSessieExercise not found");

			var stats = new DALModels.Workoutsessiestat
			{
				WorkoutsessiestatsGewicht = gewicht,
				WorkoutsessiestatsReps = reps,
				Workoutsessieexerciseworkoutsessiestats = new List<Workoutsessieexerciseworkoutsessiestat>
		{
			new Workoutsessieexerciseworkoutsessiestat
			{
				WorkoutsessieexerciseId = exerciseId
			}
		}
			};

			_context.Workoutsessiestats.Add(stats);
			await _context.SaveChangesAsync();

			return stats.WorkoutsessiestatsId;
		}


		// Haal resultaten van een WorkoutSessie op
		public async Task<(List<WorkoutSessieExerciseResult>, List<WorkoutSessieExerciseStats>)> GetResults(int workoutSessieId)
		{
			var workoutSessie = await _context.Workoutsessies
				.Include(ws => ws.Workoutsessieworkoutsessieexercises)
					.ThenInclude(wse => wse.Workoutsessieexercise)
						.ThenInclude(we => we.Workoutsessieexerciseworkoutsessiestats)
							.ThenInclude(wes => wes.Workoutsessiestats)
				.FirstOrDefaultAsync(ws => ws.WorkoutsessieId == workoutSessieId);

			if (workoutSessie == null)
			{
				throw new KeyNotFoundException("WorkoutSessie not found");
			}

			Console.WriteLine($"Workoutsessie found - Id: {workoutSessie.WorkoutsessieId}, Name: {workoutSessie.WorkoutsessieName}");

			var exerciseResults = workoutSessie.Workoutsessieworkoutsessieexercises
				.Select(wse => new WorkoutSessieExerciseResult(
					wse.Workoutsessieexercise.WorkoutsessieexerciseName,
					wse.Workoutsessieexercise.WorkoutsessieexerciseSets))
				.ToList();

			Console.WriteLine($"Number of exercises: {exerciseResults.Count}");
			foreach (var er in exerciseResults)
			{
				Console.WriteLine($"Exercise - Name: {er.Name}, Sets: {er.Sets}");
			}

			var statsResults = new List<WorkoutSessieExerciseStats>();

			foreach (var wse in workoutSessie.Workoutsessieworkoutsessieexercises)
			{
				Console.WriteLine($"Processing exercise - Id: {wse.WorkoutsessieexerciseId}, Name: {wse.Workoutsessieexercise.WorkoutsessieexerciseName}");

				foreach (var wes in wse.Workoutsessieexercise.Workoutsessieexerciseworkoutsessiestats)
				{
					if (wes.Workoutsessiestats != null)
					{
						statsResults.Add(new WorkoutSessieExerciseStats(
							wes.Workoutsessiestats.WorkoutsessiestatsGewicht,
							wes.Workoutsessiestats.WorkoutsessiestatsReps));
						Console.WriteLine($"Stat Found - Gewicht: {wes.Workoutsessiestats.WorkoutsessiestatsGewicht}, Reps: {wes.Workoutsessiestats.WorkoutsessiestatsReps}");
					}
					else
					{
						Console.WriteLine("Workoutsessiestats is null for WorkoutsessieexerciseId: " + wse.WorkoutsessieexerciseId);
					}
				}
			}

			Console.WriteLine($"Number of stats results: {statsResults.Count}");
			foreach (var sr in statsResults)
			{
				Console.WriteLine($"Stats - Gewicht: {sr.Gewicht}, Reps: {sr.Reps}");
			}

			return (exerciseResults, statsResults);
		}
	}
}
