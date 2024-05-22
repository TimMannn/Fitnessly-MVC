using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IExerciseData
    {
        List<Exercise> GetExercises();

        void SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps);

        void DeleteExercise(int ID);

        void EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID);

        Exercise GetExercise(int ExerciseID);

    }
}
