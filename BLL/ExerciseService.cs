using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
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

        public List<Exercise> GetExercises()
        {
            var result = data.GetExercises();

            return result;
        }

        public string SendExercise(string exerciseName, double exerciseGewicht,int exerciseSets, int exerciseReps)
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
                data.SendExerciseData(exerciseName, exerciseGewicht, exerciseSets, exerciseReps);
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
