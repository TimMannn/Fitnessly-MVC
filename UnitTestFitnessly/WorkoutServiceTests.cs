/*
using System.ComponentModel.DataAnnotations;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
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
            string workoutName = "Pizza";
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            // Act
            var message = workoutService.SendWorkouts(workoutName);

            // Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.SendWorkoutsData(workoutName), Times.Once);
        }

        [TestMethod]
        public void SendWorkouts_CorrectName_IsNullOrEmpty()
        {
            // Arrange
            string workoutName = "";
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            // Act
            var message = workoutService.SendWorkouts(workoutName);

            // Assert
            Assert.AreEqual("Mag niet null zijn", message);
            dataMock.Verify(d => d.SendWorkoutsData(It.IsAny<string>()), Times.Never);

        }

        [TestMethod]
        public void SendWorkouts_InCorrectName_LessThen3()
        {
            // Arrange
            string workoutName = "PD";
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            // Act
            var message = workoutService.SendWorkouts(workoutName);

            // Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
            dataMock.Verify(d => d.SendWorkoutsData(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void SendWorkouts_InCorrectName_MoreThen50()
        {
            // Arrange
            string workoutName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            // Act
            var message = workoutService.SendWorkouts(workoutName);

            // Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
            dataMock.Verify(d => d.SendWorkoutsData(It.IsAny<string>()), Times.Never);
        }





        [TestMethod]
        public void DeleteWorkouts_CorrectID_NotNull()
        {
            //Arrange
            int workoutID = 1;
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            //Act
            var message = workoutService.DeleteWorkouts(workoutID);

            //Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.DeleteWorkouts(workoutID), Times.Once);
        }

        [TestMethod]
        public void DeleteWorkouts_InCorrectID_IsNullOrEmpty()
        {
            //Arrange
            int workoutID = 0;
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);
            //Act

            var message = workoutService.DeleteWorkouts(workoutID);

            //Assert
            Assert.AreEqual("Workout ID is kleiner of gelijk aan 0", message);
            dataMock.Verify(d => d.DeleteWorkouts(It.IsAny<int>()), Times.Never);
        }





        [TestMethod]
        public void EditWorkout_CorrectName_CorrectID()
        {
            //Arrange
            string workoutName = "Pizza";
            int workoutID = 1;
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            //Act
            var message = workoutService.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.EditWorkouts(workoutName, workoutID), Times.Once);
        }

        [TestMethod]
        public void EditWorkout_InCorrectName_IsNullOrEmpty()
        {
            //Arrange
            string workoutName = "";
            int workoutID = 1;
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            //Act
            var message = workoutService.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("Mag niet null zijn", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void EditWorkout_InCorrectName_LessThen3()
        {
            //Arrange
            string workoutName = "PD";
            int workoutID = 1;
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            //Act
            var message = workoutService.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditWorkout_InCorrectName_moreThen50()
        {
            //Arrange
            string workoutName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            int workoutID = 1;
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            //Act
            var message = workoutService.EditWorkout(workoutName, workoutID);

            //Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditWorkouts_InCorrectID_NotNull()
        {
            //Arrange
            string workoutName = "Pizza";
            int workoutID = 0;
            var dataMock = new Mock<IWorkoutData>();
            var workoutService = new WorkoutService(dataMock.Object);

            //Act
            var message = workoutService.EditWorkout(workoutName,workoutID);

            //Assert
            Assert.AreEqual("Workout ID is kleiner of gelijk aan 0", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }
    }
}
*/