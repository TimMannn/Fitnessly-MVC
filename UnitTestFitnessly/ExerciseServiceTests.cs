using System.ComponentModel.DataAnnotations;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using ExerciseService = BLL.ExerciseService;

namespace UnitTestFitnessly
{
    [TestClass]
    public class ExerciseServiceTests
    {
        [TestMethod]
        public void SendExercise_CorrectName_CreateName()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int WorkoutID = 1;
            string Display = "none";
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID);

            // Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.SendExerciseData(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID), Times.Once);

        }

        [TestMethod]
        public void SendExercise_InCorrectName_NotNullOrEmpty()
        {
            // Arrange
            string exerciseName = "";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            string Display = "none";
            int WorkoutID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID);

            // Assert
            Assert.AreEqual("Mag niet null zijn", message);
            dataMock.Verify(d => d.SendExerciseData(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void SendExercise_InCorrectName_LessThen3()
        {
            // Arrange
            string exerciseName = "BP";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int WorkoutID = 1;
            string Display = "none";
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID);

            // Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
            dataMock.Verify(d => d.SendExerciseData(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void SendExercise_InCorrectName_MoreThen50()
        {
            // Arrange
            string exerciseName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int WorkoutID = 1;
            string Display = "none";
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID);

            // Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
            dataMock.Verify(d => d.SendExerciseData(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void SendExercise_InCorrectGewicht_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 0;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int WorkoutID = 1;
            string Display = "none";
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID);

            // Assert
            Assert.AreEqual("Het gewicht mag niet 0 zijn.", message);
            dataMock.Verify(d => d.SendExerciseData(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void SendExercise_InCorrectSets_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 1;
            int exerciseSets = 0;
            int exerciseReps = 1;
            int WorkoutID = 1;
            string Display = "none";
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID);

            // Assert
            Assert.AreEqual("De hoeveelheid sets mag niet 0 zijn.", message);
            dataMock.Verify(d => d.SendExerciseData(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void SendExercise_InCorrectReps_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 0;
            int WorkoutID = 1;
            string Display = "none";
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, Display, WorkoutID);

            // Assert
            Assert.AreEqual("De hoeveelheid reps mag niet 0 zijn.", message);
            dataMock.Verify(d => d.SendExerciseData(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);

        }




        [TestMethod]
        public void DeleteExercise_CorrectID_NotNull()
        {
            // Arrange
            int exerciseID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.DeleteExercise(exerciseID);

            // Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.DeleteExercise(exerciseID), Times.Once);
        }

        [TestMethod]
        public void DeleteExercise_InCorrectID_IsNullOrEmpty()
        {
            // Arrange
            int exerciseID = 0;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.DeleteExercise(exerciseID);

            // Assert
            Assert.AreEqual("Exercise ID is kleiner of gelijk aan 0", message);
            dataMock.Verify(d => d.DeleteExercise(It.IsAny<int>()), Times.Never);
        }





        [TestMethod]
        public void EditExercise_CorrectName_CreateName()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int exerciseID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID), Times.Once);
        }

        [TestMethod]
        public void EditExercise_InCorrectName_NotNullOrEmpty()
        {
            // Arrange
            string exerciseName = "";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int exerciseID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Mag niet null zijn", message);
            dataMock.Verify(d => d.EditExercise(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditExercise_InCorrectName_LessThen3()
        {
            // Arrange
            string exerciseName = "BP";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int exerciseID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
            dataMock.Verify(d => d.EditExercise(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditExercise_InCorrectName_MoreThen50()
        {
            // Arrange
            string exerciseName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int exerciseID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
            dataMock.Verify(d => d.EditExercise(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditExercise_InCorrectGewicht_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 0;
            exerciseSets = 1;
            exerciseReps = 1;
            exerciseID = 1;
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Het gewicht mag niet 0 zijn.", message);
            dataMock.Verify(d => d.EditExercise(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditExercise_InCorrectSets_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 1;
            int exerciseSets = 0;
            int exerciseReps = 1;
            int exerciseID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De hoeveelheid sets mag niet 0 zijn.", message);
            dataMock.Verify(d => d.EditExercise(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditExercise_InCorrectReps_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 0;
            int exerciseID = 1;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De hoeveelheid reps mag niet 0 zijn.", message);
            dataMock.Verify(d => d.EditExercise(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        }

        [TestMethod]
        public void EditExercise_InCorrectID_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName = "Pizza";
            double exerciseGewicht = 1;
            int exerciseSets = 1;
            int exerciseReps = 1;
            int exerciseID = 0;
            var dataMock = new Mock<IExerciseData>();
            var workoutService = new ExerciseService(dataMock.Object);

            // Act
            var message = workoutService.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Exercise ID is kleiner of gelijk aan 0", message);
            dataMock.Verify(d => d.EditExercise(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);

        }
    }
}