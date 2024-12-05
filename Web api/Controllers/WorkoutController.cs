using BLL;
using DALModels = DAL.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public ActionResult<IEnumerable<DALModels.Workout>> GetWorkouts()
        {
            var workouts = _workoutService.GetWorkouts();
            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public ActionResult<DALModels.Workout> GetWorkout(int id)
        {
            var workout = _workoutService.GetWorkout(id);
            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

		[HttpPost]
		public ActionResult<DALModels.Workout> PostWorkout(DALModels.Workout workout)
		{
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { messages = errors });
			}

			var result = _workoutService.SendWorkouts(workout.WorkoutName);
			if (result != "Alles is correct")
			{
				return BadRequest(new { message = result });
			}

			return CreatedAtAction(nameof(GetWorkout), new { id = workout.WorkoutId }, workout);
		}


		[HttpPut("{id}")]
		public ActionResult PutWorkout(int id, DALModels.Workout workout)
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

			var result = _workoutService.EditWorkout(workout.WorkoutName, id);
			if (result != "Alles is correct")
			{
				return BadRequest(new { message = result });
			}

			return Ok();
		}



		[HttpDelete("{id}")]
        public ActionResult DeleteWorkout(int id)
        {
            _workoutService.DeleteWorkouts(id);  
            return Ok();
        }
    }
}
