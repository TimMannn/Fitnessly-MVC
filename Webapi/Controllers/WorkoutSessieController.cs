using BLL;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Webapi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WorkoutSessieController : ControllerBase
	{
		private readonly WorkoutSessieService _workoutSessieService;

		public WorkoutSessieController(WorkoutSessieService workoutSessieService)
		{
			_workoutSessieService = workoutSessieService;
		}

		[HttpPost("{workoutID}")]
		public async Task<ActionResult<int>> CreateWorkoutSessie(int workoutID)
		{
			try
			{
				Console.WriteLine($"Creating workout session for workout ID: {workoutID}");
				var workoutSessieID = await _workoutSessieService.CreateWorkoutSessie(workoutID);
				Console.WriteLine($"Workout session created with ID: {workoutSessieID}");
				return Ok(workoutSessieID);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreateWorkoutSessie: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost("{workoutSessieID}/exercises")]
		public async Task<ActionResult<int>> CreateWorkoutSessieExercise(int workoutSessieID, [FromBody] WorkoutSessieExerciseModel model)
		{
			try
			{
				var workoutSessieExerciseID = await _workoutSessieService.CreateWorkoutSessieExercise(workoutSessieID, model.ExerciseName, model.Sets);
				return Ok(workoutSessieExerciseID);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreateWorkoutSessieExercise: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpPost("exercises/{exerciseID}/stats")]
		public async Task<ActionResult<int>> CreateWorkoutSessieStats(int exerciseID, [FromBody] WorkoutSessieStatsModel model)
		{
			try
			{
				var workoutSessieStatsID = await _workoutSessieService.CreateWorkoutSessieStats(exerciseID, model.Gewicht, model.Reps);
				return Ok(workoutSessieStatsID);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in CreateWorkoutSessieStats: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("{workoutSessieId}/results")]
		public async Task<IActionResult> GetResults(int workoutSessieId)
		{
			var results = await _workoutSessieService.GetResults(workoutSessieId);

			if (results.Item1 == null || results.Item2 == null)
			{
				return NotFound();
			}

			// Creëer een response object met de juiste structuur
			var response = new
			{
				WorkoutSessieExerciseResults = results.Item1,
				WorkoutSessieExerciseStats = results.Item2
			};

			// Log de resultaten voordat ze worden teruggestuurd
			Console.WriteLine("Returning results: ", response);

			return Ok(response);
		}
	}
}
