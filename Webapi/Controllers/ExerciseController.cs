using BLL;
using BLL.Models;
using DALModels = DAL.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Webapi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ExerciseController : ControllerBase
	{
		private readonly ExerciseService _exerciseService;

		public ExerciseController(ExerciseService exerciseService)
		{
			_exerciseService = exerciseService;
		}

		[HttpGet("{workoutId}")]
		public async Task<ActionResult<IEnumerable<ExerciseDetails>>> GetExercises(int workoutId)
		{
			try
			{
				var exercises = await _exerciseService.GetExercises(workoutId);
				return Ok(exercises);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetExercises: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("exercise/{id}")]
		public async Task<ActionResult<ExerciseDetails>> GetExercise(int id)
		{
			var exercise = await _exerciseService.GetExercise(id);
			if (exercise == null)
			{
				return NotFound();
			}

			return Ok(exercise);
		}

		[HttpPost]
		public async Task<ActionResult> PostExercise([FromBody] AddExerciseModel request)
		{
			Console.WriteLine($"Received Exercise: {request.ExerciseName}, {request.ExerciseGewicht}, {request.ExerciseSets}, {request.ExerciseReps}, {request.Display}, {request.WorkoutID}");

			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { messages = errors });
			}

			var result = await _exerciseService.SendExercise(request.ExerciseName, request.ExerciseGewicht, request.ExerciseSets, request.ExerciseReps, request.Display, request.WorkoutID);
			if (result != "Alles is correct")
			{
				return BadRequest(new { message = result });
			}

			return CreatedAtAction(nameof(GetExercise), new { id = request.WorkoutID }, request);
		}
		

		[HttpPut("{id}")]
		public async Task<ActionResult> PutExercise(int id, [FromBody] EditExerciseModel request)
		{
			if (id != request.ExerciseID)
			{
				return BadRequest("Mismatched exercise ID");
			}

			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { messages = errors });
			}

			var result = await _exerciseService.EditExercise(request.ExerciseName, request.ExerciseGewicht, request.ExerciseSets, request.ExerciseReps, request.ExerciseID);
			if (result != "Alles is correct")
			{
				return BadRequest(new { message = result });
			}

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteExercise(int id)
		{
			await _exerciseService.DeleteExercise(id);
			return Ok();
		}
	}
}
