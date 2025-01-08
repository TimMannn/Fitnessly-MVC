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

		[HttpPost]
		public async Task<ActionResult<int>> CreateWorkoutSessie([FromBody] int workoutID)
		{
			try
			{
				var workoutSessieID = await _workoutSessieService.CreateWorkoutSessie(workoutID);
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

		[HttpGet("{workoutSessieID}/results")]
		public async Task<ActionResult<(List<WorkoutSessieExerciseResult>, List<WorkoutSessieExerciseStats>)>> GetResults(int workoutSessieID)
		{
			try
			{
				var results = await _workoutSessieService.GetResults(workoutSessieID);
				return Ok(results);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetResults: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}
	}
}
