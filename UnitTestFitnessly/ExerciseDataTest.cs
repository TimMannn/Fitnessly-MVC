using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace UnitTestFitnessly
{
    public class ExerciseDataTest : IExerciseData
    {
        public List<Exercise> GetExercises(int WorkoutID)
        {
            return new List<Exercise>();
        }

        public void SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, int WorkoutID)
        {
            
        }

        public void DeleteExercise(int ID)
        {
            
        }

        public void EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID)
        {

        }

        public Exercise GetExercise(int ExerciseID)
        {
            return new Exercise(0, "",0 ,0 ,0);
        }
    }
}
