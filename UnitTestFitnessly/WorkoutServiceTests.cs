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

        [TestMethod]
        public void SendWorkouts_CorrectName_IsNullOrEmpty()
        {
            // Arrange
            string workoutName;

            // Act
            workoutName = "";
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.SendWorkouts(workoutName);

            // Assert
            Assert.AreEqual("Mag niet null zijn", message);
        }

        [TestMethod]
        public void SendWorkouts_InCorrectName_LessThen3()
        {
            // Arrange
            string workoutName;

            // Act
            workoutName = "PD";
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.SendWorkouts(workoutName);

            // Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
        }

        [TestMethod]
        public void SendWorkouts_InCorrectName_MoreThen50()
        {
            // Arrange
            string workoutName;

            // Act
            workoutName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.SendWorkouts(workoutName);

            // Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
        }





        [TestMethod]
        public void DeleteWorkouts_CorrectID_NotNull()
        {
            //Arrange
            int workoutID;

            //Act
            workoutID = 1;
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.DeleteWorkouts(workoutID);

            //Assert
            Assert.AreEqual("Alles is correct", message);
        }

        [TestMethod]
        public void DeleteWorkouts_InCorrectID_IsNullOrEmpty()
        {
            //Arrange
            int workoutID;

            //Act
            workoutID = 0;
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.DeleteWorkouts(workoutID);

            //Assert
            Assert.AreEqual("Workout ID is kleiner of gelijk aan 0", message);
        }





        [TestMethod]
        public void EditWorkout_CorrectName_CorrectID()
        {
            //Arrange
            string workoutName;
            int workoutID;

            //Act
            workoutName = "Pizza";
            workoutID = 1;
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("Alles is correct", message);
        }

        [TestMethod]
        public void EditWorkout_InCorrectName_IsNullOrEmpty()
        {
            //Arrange
            string workoutName;
            int workoutID;

            //Act
            workoutName = "";
            workoutID = 1;
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("Mag niet null zijn", message);
        }

        [TestMethod]
        public void EditWorkout_InCorrectName_LessThen3()
        {
            //Arrange
            string workoutName;
            int workoutID;

            //Act
            workoutName = "PD";
            workoutID = 1;
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
        }

        [TestMethod]
        public void EditWorkout_InCorrectName_moreThen50()
        {
            //Arrange
            string workoutName;
            int workoutID;

            //Act
            workoutName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            workoutID = 1;
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
        }

        [TestMethod]
        public void EditWorkouts_InCorrectID_NotNull()
        {
            //Arrange
            string workoutName;
            int workoutID;

            //Act
            workoutName = "Pizza";
            workoutID = 0;
            var data = new WorkoutDataTest();
            WorkoutService workoutservice = new WorkoutService(data);
            var message = workoutservice.EditWorkout(workoutName,workoutID);

            //Assert
            Assert.AreEqual("Workout ID is kleiner of gelijk aan 0", message);
        }
    }
}