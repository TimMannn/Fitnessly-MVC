using BLL;
using DALModels = DAL.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Web_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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
				var workouts = await _workoutService.GetWorkouts(); // Voeg async/await toe
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
			var workout = await _workoutService.GetWorkout(id); // Voeg async/await toe
			if (workout == null)
			{
				return NotFound();
			}

			return Ok(workout);
		}

		[HttpPost]
		public async Task<ActionResult<DALModels.Workout>> PostWorkout(DALModels.Workout workout)
		{
			Console.WriteLine("Hoiii");
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { messages = errors });
			}
			Console.WriteLine("1");
			var result = await _workoutService.SendWorkouts(workout.WorkoutName);
			if (result != "Alles is correct")
			{
				return BadRequest(new { message = result });
			}
			Console.WriteLine("2");
			return CreatedAtAction(nameof(GetWorkout), new { id = workout.WorkoutId }, workout);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> PutWorkout(int id, DALModels.Workout workout)
		{
			if (id != workout.WorkoutId)
			{
				return BadRequest("Mismatched workout ID");
			}

			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { messages = errors });
			}

			var result = await _workoutService.EditWorkout(workout.WorkoutName, id);
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
