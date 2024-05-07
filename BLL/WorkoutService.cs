using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DeleteWorkouts(int ID)
        {
            data.DeleteWorkouts(ID);
        }
    }
}
