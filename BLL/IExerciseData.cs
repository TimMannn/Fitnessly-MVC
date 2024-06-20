using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IExerciseData
    {
        List<Exercise> GetExercises(int WorkoutID);

        void SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string display, int WorkoutID);

        void DeleteExercise(int ID);

        void EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID);

        Exercise GetExercise(int ExerciseID);

        void DisplayTrueExercise();
        void DisplayFalseExercise(int ExerciseID);

    }
}
