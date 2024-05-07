using System.ComponentModel.DataAnnotations;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using WorkoutService = BLL.WorkoutService;

namespace UnitTestFitnessly
{
    [TestClass]
    public class WorkoutServiceTests
    {
        [TestMethod]
        public void SendWorkouts_CorrectName_CreateName()
        {
            // Arrange
            string workoutName;

            // Act
            workoutName = "Pizza";
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.SendWorkouts(workoutName);
            // Assert
            Assert.AreEqual("Alles is correct", message);
        }
    }
}