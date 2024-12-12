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
	public class WorkoutController : ControllerBase
	{
		private readonly WorkoutService _workoutService;

		public WorkoutController(WorkoutService workoutService)
		{
			_workoutService = workoutService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<DALModels.Workout>>> GetWorkouts()
		{
			try
			{
				var workouts = await _workoutService.GetWorkouts(); 
				return Ok(workouts);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetWorkouts: {ex.Message}");
				return StatusCode(500, "Internal server error");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<DALModels.Workout>> GetWorkout(int id)
		{
			var workout = await _workoutService.GetWorkout(id); 
			if (workout == null)
			{
				return NotFound();
			}

			return Ok(workout);
		}

		[HttpPost]
		public async Task<ActionResult<DALModels.Workout>> PostWorkout([FromBody] AddWorkoutModel request)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { messages = errors });
			}

			var result = await _workoutService.SendWorkouts(request.WorkoutName, request.UserId);
			if (result != "Alles is correct")
			{
				return BadRequest(new { message = result });
			}

			return CreatedAtAction(nameof(GetWorkout), new { id = request.UserId }, request);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<DALModels.Workout>> PutWorkout(int id, [FromBody] EditWorkoutModel request)
		{
			if (id != request.WorkoutId)
			{
				return BadRequest("Mismatched workout ID");
			}

			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { messages = errors });
			}

			var result = await _workoutService.EditWorkout(request.WorkoutName, request.WorkoutId, request.UserId);
			if (result != "Alles is correct")
			{
				return BadRequest(new { message = result });
			}

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteWorkout(int id)
		{
			await _workoutService.DeleteWorkouts(id);
			return Ok();
		}
	}

}
