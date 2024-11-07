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
        public List<ExerciseDetails> GetExercises(int WorkoutID)
        {
            return new List<ExerciseDetails>();
        }

        public void SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string Display, int WorkoutID)
        {
            
        }

        public void DeleteExercise(int ID)
        {
            
        }

        public void EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID)
        {

        }

        public ExerciseDetails GetExercise(int ExerciseID)
        {
            return new ExerciseDetails(0, "",0 ,0 ,0, "none");
        }

        public void DisplayTrueExercise()
        {

        }

        public void DisplayFalseExercise(int ExerciseID)
        {

        }
    }
}
