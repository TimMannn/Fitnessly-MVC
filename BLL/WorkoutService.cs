using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkoutService
    {
        public List<Workout> GetWorkouts()
        {
            // haal op uit database

            // 

            return new List<Workout>() { new Workout(id:1, name: "Leg day") };
        }
    }
}
