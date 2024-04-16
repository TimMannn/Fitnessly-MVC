using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkoutService
    {
        /*
        public Workout GetWorkout()
        {
            return new Workout(id: 1, name: "Leg day") ;
        }
        */

        public List<Workout> GetWorkouts()
        {
            // haal op uit database komt hier

            return new List<Workout> 
            { 
                new Workout(id:1, name: "Push day"),
                new Workout(id:2, name: "Pull day"), 
                new Workout(id:3, name: "Leg day"),
                new Workout(id:4, name: "Chest day"),
                new Workout(id:5, name: "Back day"),
                new Workout(id:6, name: "Shoulder day"),
                new Workout(id:7, name: "Arm day"),
                new Workout(id:8, name: "Cardio day")
            };
        }
    }
}
