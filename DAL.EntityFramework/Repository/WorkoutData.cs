using BLL;
using DAL.EntityFramework.Context;
using DALModels = DAL.EntityFramework.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repository
{
    public class WorkoutData : IWorkoutData
    {
        private readonly FitnesslybackupContext _context;

        public WorkoutData(FitnesslybackupContext context)
        {
            _context = context;
        }

        // Haalt op uit database
        public async Task<List<WorkoutDetails>> GetWorkouts(string userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .Select(w => new WorkoutDetails(w.WorkoutId, w.WorkoutName, w.UserId))
                .ToListAsync();
        }

        // Verstuurd naar database
        public async Task SendWorkoutsData(string workoutName, string userId)
        {
            Console.WriteLine("ik ben zelfs in de DAL laag gekomen");
            var workout = new DALModels.Workout { WorkoutName = workoutName, UserId = userId };
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }

        // Verwijder uit database
        public async Task DeleteWorkouts(int ID)
        {
            var workout = _context.Workouts.Find(ID);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
        }

        // Bewerken in database
        public async Task EditWorkouts(string newWorkoutName, int workoutID)
        {
            var workout = _context.Workouts.Find(workoutID);
            if (workout != null)
            {
                workout.WorkoutName = newWorkoutName;
                _context.Workouts.Update(workout);
                await _context.SaveChangesAsync();
            }
        }

        // Haal specifieke workout op
        public async Task<WorkoutDetails> GetWorkout(int workoutID)
        {
            var workout = _context.Workouts.FirstOrDefault(w => w.WorkoutId == workoutID);
            if (workout == null)
            {
                return null;
            }

            return new WorkoutDetails(workout.WorkoutId, workout.WorkoutName, workout.UserId);
        }
    }
}
