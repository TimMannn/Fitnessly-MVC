using Fitnessly_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fitnessly_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            // roep de BLL aan
            var result = new BLL.WorkoutService().GetWorkout();

            // zet data in viewmodel
            var workoutViewModel = new WorkoutViewModel();
            workoutViewModel.Id = result.Id;
            workoutViewModel.Name = result.Name;

            // geef viemodel aan view
            return View(workoutViewModel);
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
