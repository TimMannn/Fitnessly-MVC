using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_api.Models;


namespace Web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly FitnesslybackupContext _fitnesslybackupContext;
        public ApiController(FitnesslybackupContext fitnesslybackupContext)
        {
            _fitnesslybackupContext = fitnesslybackupContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            if (_fitnesslybackupContext.Workouts == null)
            {
                return NotFound();
            }

            return await _fitnesslybackupContext.Workouts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(int id)
        {
            if (_fitnesslybackupContext.Workouts == null)
            {
                return NotFound();
            }

            var workout = await _fitnesslybackupContext.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            return workout;
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
        {
            _fitnesslybackupContext.Workouts.Add(workout);
            await _fitnesslybackupContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkout), new { id = workout.WorkoutId }, workout);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutWorkout(int id, Workout workout)
        {
            if (id != workout.WorkoutId)
            {
                return BadRequest();
            }

            _fitnesslybackupContext.Entry(workout).State = EntityState.Modified;

            try
            {
                await _fitnesslybackupContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkout(int id)
        {
            if (_fitnesslybackupContext.Workouts == null)
            {
                return NotFound();
            }

            var workout = await _fitnesslybackupContext.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _fitnesslybackupContext.Workouts.Remove(workout);
            await _fitnesslybackupContext.SaveChangesAsync();

            return Ok();
        }
    }
}
