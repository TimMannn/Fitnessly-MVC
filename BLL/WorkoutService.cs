using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Crud;

namespace BLL
{
    public class WorkoutService
    {
        private readonly IWorkoutData data;

        public WorkoutService(IWorkoutData data)
        {
            this.data = data;
        }

        public List<Workout> GetWorkouts()
        {
            var result = data.GetWorkouts();

            return result;
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
                data.SendWorkoutsData(workoutName);
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
                data.DeleteWorkouts(ID);
            }

            return message;
        }

        public string EditWorkout(string NewWorkoutName, int WorkoutID)
        {
            var message = "Alles is correct";
            if (string.IsNullOrEmpty(NewWorkoutName))
            {
                message = "Mag niet null zijn";
            }
            else if (NewWorkoutName.Length < 3)
            {
                message = "De naam moet minimaal 3 letters lang zijn";
            }
            else if (NewWorkoutName.Length > 50)
            {
                message = "De naam mag maximaal 50 letters lang zijn";
            }
            else if (WorkoutID <= 0)
            {
                message = "Workout ID is kleiner of gelijk aan 0";
            }
            else
            {
                data.EditWorkouts(NewWorkoutName, WorkoutID);
            }
            return message;
        }

        public Workout GetWorkout(int Id)
        {
            return data.GetWorkout(Id);
        }
    }
}
