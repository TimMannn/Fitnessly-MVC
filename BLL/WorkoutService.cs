using System.Collections.Generic;

namespace BLL
{
    public class WorkoutService
    {
        private readonly IWorkoutData _workoutData;

        public WorkoutService(IWorkoutData workoutData)
        {
            _workoutData = workoutData;
        }

        public List<WorkoutDetails> GetWorkouts()
        {
            return _workoutData.GetWorkouts();
        }

        public string SendWorkouts(string workoutName)
        {
            var message = "Alles is correct";
            if (string.IsNullOrEmpty(workoutName))
            {
                message = "Mag niet null zijn";
            }
            else if (workoutName.Length < 3)
            {
                message = "De naam moet minimaal 3 letters lang zijn";
            }
            else if (workoutName.Length > 50)
            {
                message = "De naam mag maximaal 50 letters lang zijn";
            }
            else
            {
                _workoutData.SendWorkoutsData(workoutName);
            }
            return message;
        }

        public string DeleteWorkouts(int ID)
        {
            var message = "Alles is correct";
            if (ID <= 0)
            {
                message = "Workout ID is kleiner of gelijk aan 0";
            }
            else
            {
                _workoutData.DeleteWorkouts(ID);
            }

            return message;
        }

        public string EditWorkout(string newWorkoutName, int workoutID)
        {
            var message = "Alles is correct";
            if (string.IsNullOrEmpty(newWorkoutName))
            {
                message = "Mag niet null zijn";
            }
            else if (newWorkoutName.Length < 3)
            {
                message = "De naam moet minimaal 3 letters lang zijn";
            }
            else if (newWorkoutName.Length > 50)
            {
                message = "De naam mag maximaal 50 letters lang zijn";
            }
            else if (workoutID <= 0)
            {
                message = "Workout ID is kleiner of gelijk aan 0";
            }
            else
            {
                _workoutData.EditWorkouts(newWorkoutName, workoutID);
            }
            return message;
        }

        public WorkoutDetails GetWorkout(int id)
        {
            return _workoutData.GetWorkout(id);
        }
    }
}
