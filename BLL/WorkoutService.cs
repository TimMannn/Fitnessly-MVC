using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkoutService
    {
        public Workout GetWorkout()
        {
            return new Workout(id: 1, name: "Leg day") ;
        }

        public List<Workout> GetWorkouts()
        {
            // haal op uit database komt hier

            return new List<Workout>() 
            { 
                new Workout(id:1, name: "Leg day"),
                new Workout(id:2, name: "Push day"), 
                new Workout(id:3, name: "Pull day")
            };
        }
    }
}
