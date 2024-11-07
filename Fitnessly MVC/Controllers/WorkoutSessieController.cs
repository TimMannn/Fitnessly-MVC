using Fitnessly_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using BLL;
using DAL;

namespace Fitnessly_MVC.Controllers
{
    public class WorkoutSessieController : Controller
    {
        private readonly ILogger<WorkoutSessieController> _logger;

        private readonly IExerciseData _exerciseData;

        private readonly IWorkoutData _workoutData;

        private readonly IWorkoutSessieData _workoutSessieData;

        private readonly WorkoutService _workoutservice;

        private readonly ExerciseService _exerciseservice;

        private readonly WorkoutSessieService _workoutSessieService;

        public WorkoutSessieController(ILogger<WorkoutSessieController> logger, IExerciseData exerciseData, IWorkoutData workoutData, IWorkoutSessieData workoutSessieData)
        {
            _logger = logger;
            _exerciseData = exerciseData;
            _workoutData = workoutData;
            _exerciseservice = new ExerciseService(exerciseData);
            _workoutSessieService = new WorkoutSessieService(workoutSessieData);
            _workoutservice = new WorkoutService(workoutData);
        }

        public IActionResult WorkoutSessieFirstLoad(int WorkoutID)
        {
            _workoutSessieService.CreateWorkoutSessie(WorkoutID);
            _exerciseservice.DisplayTrueExercise();
            var workoutSessieViewModel = new WorkoutSessieViewModel

            {
                Exercises = _exerciseservice.GetExercises(WorkoutID),
                WorkoutID = WorkoutID
            };

            return View("WorkoutSessie", workoutSessieViewModel);
        }

        public IActionResult WorkoutSessie(int WorkoutID)
        {
            var workoutSessieViewModel = new WorkoutSessieViewModel

            {
                Exercises = _exerciseservice.GetExercises(WorkoutID),
                WorkoutID = WorkoutID
            };

            return View(workoutSessieViewModel);
        }

        public IActionResult WorkoutSessieResultaat()
        {
            var (workoutSessieExerciseResults, workoutSessieExerciseStats) = _workoutSessieService.GetResults();
            var workoutSessieResultsViewModel = new WorkoutSessieResultsViewModel
            {
                workoutSessieExerciseResults = workoutSessieExerciseResults,
                workoutSessieExerciseStats = workoutSessieExerciseStats
            };
            return View("WorkoutSessieResultaat", workoutSessieResultsViewModel);
        }

        public IActionResult EditStats(WorkoutSessieViewModel model, string WorkoutSessieStatsName, double WorkoutSessieStatsGewicht, int WorkoutSessieStatsSets, int WorkoutSessieStatsReps, int WorkoutID, int ExerciseID)
        {
            _exerciseservice.DisplayFalseExercise(ExerciseID);
            _workoutSessieService.CreateWorkoutSessieExercise(WorkoutSessieStatsName, WorkoutSessieStatsSets);
            foreach (var set in model.SetsModels)
            {
                double gewicht = set.Gewicht;
                int reps = set.Reps;
                _workoutSessieService.CreateWorkoutSessieStats(gewicht, reps);
            }
            return RedirectToAction("WorkoutSessie", new { WorkoutID = WorkoutID });
        }

        public IActionResult WorkoutSessieStats(int ExerciseID, int WorkoutID)
        {
            ExerciseDetails exercise = _exerciseservice.GetExercise(ExerciseID);
            var workoutSessieViewModel = new WorkoutSessieViewModel()
            {
                WorkoutID = WorkoutID,
                Id = exercise.Id,
                Name = exercise.Name,
                Gewicht = exercise.Gewicht,
                Sets = exercise.Sets,
                Reps = exercise.Reps
            };

            return View("EditStats", workoutSessieViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
