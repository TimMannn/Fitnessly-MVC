using Fitnessly_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BLL;
using DAL;
using SqlServerDAL;

namespace Fitnessly_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IWorkoutData _workoutData;

        private readonly WorkoutService _workoutservice;
        public HomeController(ILogger<HomeController> logger, IWorkoutData workoutData)
        {
            _logger = logger;
            _workoutData = workoutData;
            _workoutservice = new BLL.WorkoutService(workoutData);
        }

        public IActionResult Index()
        {
            // zet data in viewmodel
            var workoutViewModel = new WorkoutViewModel
            {
                Workouts = _workoutservice.GetWorkouts()
            };

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

        public IActionResult Edit()
        {
            return View("Edit");
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
