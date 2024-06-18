using Fitnessly_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using BLL;
using DAL;
using SqlServerDAL;

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

        public IActionResult WorkoutSessie(int WorkoutID)
        {
            _workoutSessieService.CreateWorkoutSessie(WorkoutID);

            var exerciseViewModel = new ExerciseViewModel

            {
                Exercises = _exerciseservice.GetExercises(WorkoutID),
                WorkoutID = WorkoutID
            };

            return View(exerciseViewModel);
        }

        public IActionResult EditStats(WorkoutSessieViewModel model, string WorkoutSessieStatsName, double WorkoutSessieStatsGewicht, int WorkoutSessieStatsSets, int WorkoutSessieStatsReps, int WorkoutID)
        {
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
            Exercise exercise = _exerciseservice.GetExercise(ExerciseID);
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
