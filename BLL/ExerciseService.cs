using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ExerciseService
    {
        private readonly IExerciseData data;

        public ExerciseService(IExerciseData data)
        {
            this.data = data;
        }

        public List<Exercise> GetExercises(int WorkoutID)
        {
            var result = data.GetExercises(WorkoutID);

            return result;
        }

        public string SendExercise(string exerciseName, double exerciseGewicht,int exerciseSets, int exerciseReps, int WorkoutID)
        {
            var message = "Alles is correct";
            if (string.IsNullOrEmpty(exerciseName))
            {
                message = "Mag niet null zijn";
            }
            else if (exerciseName.Length < 3)
            {
                message = "De naam moet minimaal 3 letters lang zijn";
            }
            else if (exerciseName.Length > 50)
            {
                message = "De naam mag maximaal 50 letters lang zijn";
            }
            else if (exerciseGewicht == 0)
            {
                message = "Het gewicht mag niet 0 zijn.";
            }
            else if (exerciseSets == 0)
            {
                message = "De hoeveelheid sets mag niet 0 zijn.";
            }
            else if (exerciseReps == 0)
            {
                message = "De hoeveelheid reps mag niet 0 zijn.";
            }
            else
            {
                data.SendExerciseData(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);
            }
            return message;
        }

        public string DeleteExercise(int ID)
        {
            var message = "Alles is correct";
            if (ID <= 0)
            {
                message = "Exercise ID is kleiner of gelijk aan 0";
            }
            else
            {
                data.DeleteExercise(ID);
            }

            return message;
        }

        public string EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID)
        {
            var message = "Alles is correct";
            if (string.IsNullOrEmpty(NewExerciseName))
            {
                message = "Mag niet null zijn";
            }
            else if (NewExerciseName.Length < 3)
            {
                message = "De naam moet minimaal 3 letters lang zijn";
            }
            else if (NewExerciseName.Length > 50)
            {
                message = "De naam mag maximaal 50 letters lang zijn";
            }
            else if (NewExerciseGewicht == 0)
            {
                message = "Het gewicht mag niet 0 zijn.";
            }
            else if (NewExerciseSets == 0)
            {
                message = "De hoeveelheid sets mag niet 0 zijn.";
            }
            else if (NewExerciseReps == 0)
            {
                message = "De hoeveelheid reps mag niet 0 zijn.";
            }
            else if (ExerciseID <= 0)
            {
                message = "Exercise ID is kleiner of gelijk aan 0";
            }
            else
            {
                data.EditExercise(NewExerciseName, NewExerciseGewicht, NewExerciseSets, NewExerciseReps, ExerciseID);
            }
            return message;
        }

        public Exercise GetExercise(int Id)
        {
            return data.GetExercise(Id);
        }
    }
}
