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
        public HomeController(ILogger<HomeController> logger, IWorkoutData workoutData)
        {
            _logger = logger;
            _workoutData = workoutData;
        }

        public IActionResult Index()
        {

            // roep de BLL aan
            var workoutData = new WorkoutData();
            var workouts = new BLL.WorkoutService(workoutData).GetWorkouts();

            // zet data in viewmodel
            var workoutViewModel = new WorkoutViewModel
            {
                Workouts = workouts
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
            _workoutData.SendWorkouts(workoutName);
            return RedirectToAction("Index");
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
