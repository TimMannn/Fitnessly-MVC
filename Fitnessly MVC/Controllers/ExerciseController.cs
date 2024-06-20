using Fitnessly_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using BLL;
using DAL;
using SqlServerDAL;

namespace Fitnessly_MVC.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ILogger<ExerciseController> _logger;

        private readonly IExerciseData _exerciseData;

        private readonly IWorkoutData _workoutData;

        private readonly WorkoutService _workoutservice;

        private readonly ExerciseService _exerciseservice;

        public ExerciseController(ILogger<ExerciseController> logger, IExerciseData exerciseData, IWorkoutData workoutData)
        {
            _logger = logger;
            _exerciseData = exerciseData;
            _workoutData = workoutData;
            _exerciseservice = new ExerciseService(exerciseData);
        }

        public IActionResult Exercise(int WorkoutID)
        {
            var exerciseViewModel = new ExerciseViewModel

            {
                Exercises = _exerciseservice.GetExercises(WorkoutID),
                WorkoutID = WorkoutID
            };

            return View(exerciseViewModel);
        }

        public IActionResult NewExercise(int WorkoutID)
        {
            var exerciseViewModel = new ExerciseViewModel
            {
                WorkoutID = WorkoutID
            };

            return View(exerciseViewModel);
        }

        public IActionResult AddNewExercise(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string display, int WorkoutID)
        {
            var exerciseViewModel = new ExerciseViewModel
            {
                WorkoutID = WorkoutID
            };

            bool error = false;
            if (exerciseName.Length < 3)
            {
                ModelState.AddModelError("exerciseName", "De naam mag niet korter zijn dan 3 tekens.");
                error = true;
            }

            else if (exerciseName.Length > 50)
            {
                ModelState.AddModelError("exerciseName", "De naam mag niet langer zijn dan 50 tekens.");
                error = true;
            }

            if (exerciseGewicht == 0)
            {
                ModelState.AddModelError("exerciseGewicht", "Het gewicht mag niet 0 zijn.");
                error = true;
            }

            if (exerciseSets == 0)
            {
                ModelState.AddModelError("exerciseSets", "De hoeveelheid sets mag niet 0 zijn.");
                error = true;
            }

            if (exerciseReps == 0)
            {
                ModelState.AddModelError("exerciseReps", "De hoeveelheid reps mag niet 0 zijn.");
            }

            if (error == true)
            {
                return View("NewExercise");
            }
            _exerciseservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, display, WorkoutID);

            return RedirectToAction("Exercise", exerciseViewModel);

        }

        public IActionResult DeleteExercise(int exerciseID, int WorkoutID)
        {
            var exerciseViewModel = new ExerciseViewModel
            {
                WorkoutID = WorkoutID
            };
            _exerciseservice.DeleteExercise(exerciseID);
            return RedirectToAction("Exercise", exerciseViewModel);
        }

        public IActionResult EditExercise(string newExerciseName, double newExerciseGewicht, int newExerciseSets, int newExerciseReps, int ExerciseID, int WorkoutID)
        {
            _exerciseservice.EditExercise(newExerciseName, newExerciseGewicht, newExerciseSets, newExerciseReps, ExerciseID);
            return RedirectToAction("Exercise", new { WorkoutID = WorkoutID });
        }

        public IActionResult ExerciseEdit(int ID, int WorkoutID)
        {
            Exercise exercise = _exerciseservice.GetExercise(ID);
            var exerciseViewModel = new ExerciseViewModel()
            {
                WorkoutID = WorkoutID,
                Id = exercise.Id,
                Name = exercise.Name,
                Gewicht = exercise.Gewicht,
                Sets = exercise.Sets,
                Reps = exercise.Reps
            };

            return View("EditExercise", exerciseViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
