﻿using BLL;

namespace SqlServerDAL
{
    public class WorkoutSqlServerData : IWorkoutData
    {
        public List<WorkoutDetails> GetWorkouts()
        {
            throw new NotImplementedException();
        }

        public void SendWorkoutsData(string workoutName)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkouts(int ID)
        {
            throw new NotImplementedException();
        }

        public void EditWorkouts(string NewWorkoutName, int WorkoutID)
        {
            throw new NotImplementedException();
        }

        public WorkoutDetails GetWorkout(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
