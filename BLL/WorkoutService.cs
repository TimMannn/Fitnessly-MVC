using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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

            // validatie

            // 

            return result;
        }
    }
}
