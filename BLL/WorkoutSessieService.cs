using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WorkoutSessieService
    {
        private readonly IWorkoutSessieData data;

        public WorkoutSessieService(IWorkoutSessieData data)
        {
            this.data = data;
        }

        public void CreateWorkoutSessie(int WorkoutID)
        {
            data.CreateWorkoutSessie(WorkoutID);
        }

        public void CreateWorkoutSessieExercise (string WorkoutSessieExerciseName, int WorkoutSessieStatsSets)
        {
            data.CreateWorkoutSessieExercise(WorkoutSessieExerciseName, WorkoutSessieStatsSets);
        }

    public void CreateWorkoutSessieStats(double WorkoutSessieStatsGewicht, int WorkoutSessieStatsReps)
        {
            data.CreateWorkoutSessieStats(WorkoutSessieStatsGewicht, WorkoutSessieStatsReps);
        }

        public (List<WorkoutSessieExerciseResult>, List<WorkoutSessieExerciseStats>) GetResults()
        {
            return data.GetResults();
        }
    }
}
