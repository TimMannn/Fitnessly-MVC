using Fitnessly_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using BLL;
using DAL;
using SqlServerDAL;

namespace Fitnessly_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWorkoutData _workoutData;

        private readonly IExerciseData _exerciseData;

        private readonly WorkoutService _workoutservice;

        private readonly ExerciseService _exerciseservice;
        public HomeController(ILogger<HomeController> logger, IWorkoutData workoutData, IExerciseData exerciseData)
        {
            _logger = logger;
            _workoutData = workoutData;
            _exerciseData = exerciseData;
            _workoutservice = new BLL.WorkoutService(workoutData);
            _exerciseservice = new ExerciseService(exerciseData);
        }

        public IActionResult Index()
        {
            var workOutDomainModels = _workoutservice.GetWorkouts();


            // zet data in viewmodel
            var workoutViewModel = new WorkoutOverViewModel
            {
                Workouts = new List<WorkoutDetailViewModel>()
            };

            foreach (WorkoutDetails workout in workOutDomainModels)
            {
                var model = new WorkoutDetailViewModel();
                model.Id = workout.Id;
                model.Name = workout.Name;
                workoutViewModel.Workouts.Add(model);
            }

            // geef viemodel aan view
            return View(workoutViewModel);
        }

        
        public IActionResult New()
        {
            return View();
        }

        public IActionResult NewWorkout(string workoutName)
        {
            if (workoutName.Length < 3)
            {
                ModelState.AddModelError("workoutName", "De naam mag niet korter zijn dan 3 tekens.");
                return View("New");
            }

            else if (workoutName.Length > 50)
            {
                ModelState.AddModelError("workoutName", "De naam mag niet langer zijn dan 50 tekens.");
                return View("New");
            }

            _workoutservice.SendWorkouts(workoutName);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteWorkout(int workoutID)
        {
            _workoutservice.DeleteWorkouts(workoutID);
            return RedirectToAction("Index");
        }

        public IActionResult EditWorkout(string newWorkoutName, int WorkoutID)
        {
            _workoutservice.EditWorkout(newWorkoutName, WorkoutID);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            WorkoutDetails workout = _workoutservice.GetWorkout(ID);
           var viewModel = new WorkoutDetailViewModel();
           viewModel.Id = workout.Id;
           viewModel.Name = workout.Name;

            return View("Edit", viewModel);
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
