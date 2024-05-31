using System.ComponentModel.DataAnnotations;
using BLL;
using DAL;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int WorkoutID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            WorkoutID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);

            // Assert
            Assert.AreEqual("Alles is correct", message);
        }

        [TestMethod]
        public void SendExercise_InCorrectName_NotNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int WorkoutID;

            // Act
            exerciseName = "";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            WorkoutID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);

            // Assert
            Assert.AreEqual("Mag niet null zijn", message);
        }

        [TestMethod]
        public void SendExercise_InCorrectName_LessThen3()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int WorkoutID;

            // Act
            exerciseName = "BP";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            WorkoutID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);

            // Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
        }

        [TestMethod]
        public void SendExercise_InCorrectName_MoreThen50()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int WorkoutID;

            // Act
            exerciseName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            WorkoutID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);

            // Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
        }

        [TestMethod]
        public void SendExercise_InCorrectGewicht_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int WorkoutID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 0;
            exerciseSets = 1;
            exerciseReps = 1;
            WorkoutID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);

            // Assert
            Assert.AreEqual("Het gewicht mag niet 0 zijn.", message);
        }

        [TestMethod]
        public void SendExercise_InCorrectSets_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int WorkoutID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 1;
            exerciseSets = 0;
            exerciseReps = 1;
            WorkoutID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);

            // Assert
            Assert.AreEqual("De hoeveelheid sets mag niet 0 zijn.", message);
        }

        [TestMethod]
        public void SendExercise_InCorrectReps_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int WorkoutID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 0;
            WorkoutID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.SendExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, WorkoutID);

            // Assert
            Assert.AreEqual("De hoeveelheid reps mag niet 0 zijn.", message);
        }




        [TestMethod]
        public void DeleteExercise_CorrectID_NotNull()
        {
            // Arrange
            int exerciseID;

            // Act
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.DeleteExercise(exerciseID);

            // Assert
            Assert.AreEqual("Alles is correct", message);
        }

        [TestMethod]
        public void DeleteExercise_InCorrectID_IsNullOrEmpty()
        {
            // Arrange
            int exerciseID;

            // Act
            exerciseID = 0;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.DeleteExercise(exerciseID);

            // Assert
            Assert.AreEqual("Exercise ID is kleiner of gelijk aan 0", message);
        }





        [TestMethod]
        public void EditExercise_CorrectName_CreateName()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Alles is correct", message);
        }

        [TestMethod]
        public void EditExercise_InCorrectName_NotNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;

            // Act
            exerciseName = "";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Mag niet null zijn", message);
        }

        [TestMethod]
        public void EditExercise_InCorrectName_LessThen3()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;

            // Act
            exerciseName = "BP";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
        }

        [TestMethod]
        public void EditExercise_InCorrectName_MoreThen50()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;

            // Act
            exerciseName = "ababababababababababababababababababababababababababababababababababababababababababababab";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
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

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 0;
            exerciseSets = 1;
            exerciseReps = 1;
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Het gewicht mag niet 0 zijn.", message);
        }

        [TestMethod]
        public void EditExercise_InCorrectSets_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 1;
            exerciseSets = 0;
            exerciseReps = 1;
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De hoeveelheid sets mag niet 0 zijn.", message);
        }

        [TestMethod]
        public void EditExercise_InCorrectReps_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 0;
            exerciseID = 1;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("De hoeveelheid reps mag niet 0 zijn.", message);
        }

        [TestMethod]
        public void EditExercise_InCorrectID_IsNullOrEmpty()
        {
            // Arrange
            string exerciseName;
            double exerciseGewicht;
            int exerciseSets;
            int exerciseReps;
            int exerciseID;

            // Act
            exerciseName = "Pizza";
            exerciseGewicht = 1;
            exerciseSets = 1;
            exerciseReps = 1;
            exerciseID = 0;
            var data = new ExerciseDataTest();
            ExerciseService workoutservice = new ExerciseService(data);
            var message = workoutservice.EditExercise(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, exerciseID);

            // Assert
            Assert.AreEqual("Exercise ID is kleiner of gelijk aan 0", message);
        }
    }
}