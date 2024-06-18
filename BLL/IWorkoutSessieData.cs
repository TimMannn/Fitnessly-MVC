using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IWorkoutSessieData
    {
        void CreateWorkoutSessie(int WorkoutID);
        void CreateWorkoutSessieExercise(string WorkoutSessieExerciseName, int WorkoutSessieStatsSets);
        void CreateWorkoutSessieStats(double WorkoutSessieStatsGewicht, int WorkoutSessieStatsReps);
    }
}
