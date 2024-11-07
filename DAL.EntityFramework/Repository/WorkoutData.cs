using BLL;
using DAL.EntityFramework.Context;
using DALModels = DAL.EntityFramework.Models;
using System.Collections.Generic;
using System.Linq;

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
        public List<WorkoutDetails> GetWorkouts()
        {
            return _context.Workouts
                .Select(w => new WorkoutDetails(w.WorkoutId, w.WorkoutName))
                .ToList();
        }

        // Verstuurd naar database
        public void SendWorkoutsData(string workoutName)
        {
            var workout = new DALModels.Workout { WorkoutName = workoutName };
            _context.Workouts.Add(workout);
            _context.SaveChanges();
        }

        // Verwijder uit database
        public void DeleteWorkouts(int ID)
        {
            var workout = _context.Workouts.Find(ID);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                _context.SaveChanges();
            }
        }

        // Bewerken in database
        public void EditWorkouts(string newWorkoutName, int workoutID)
        {
            var workout = _context.Workouts.Find(workoutID);
            if (workout != null)
            {
                workout.WorkoutName = newWorkoutName;
                _context.Workouts.Update(workout);
                _context.SaveChanges();
            }
        }

        // Haal specifieke workout op
        public WorkoutDetails GetWorkout(int workoutID)
        {
            var workout = _context.Workouts.FirstOrDefault(w => w.WorkoutId == workoutID);
            if (workout == null)
            {
                return null;
            }

            return new WorkoutDetails(workout.WorkoutId, workout.WorkoutName);
        }
    }
}
