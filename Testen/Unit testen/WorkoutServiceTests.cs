using System.ComponentModel.DataAnnotations;
using BLL;
using DAL.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using WorkoutService = BLL.WorkoutService;

namespace UnitTestFitnessly
{
    [TestClass]
    public class WorkoutServiceTests
    {
        [TestMethod]
        public async Task SendWorkouts_CorrectName_CreateName()
        {
            // Arrange
            string workoutName = "Pizza";
            string userId = "";
            var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			// Act
			var message = await workoutService.SendWorkouts(workoutName, userId);

            // Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.SendWorkoutsData(workoutName, userId), Times.Once);
        }

        [TestMethod]
        public async Task SendWorkouts_CorrectName_IsNullOrEmpty()
        {
            // Arrange
            string workoutName = "";
			string userId = "";
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			// Act
			var message = await workoutService.SendWorkouts(workoutName, userId);

            // Assert
            Assert.AreEqual("Mag niet null zijn", message);
            dataMock.Verify(d => d.SendWorkoutsData(It.IsAny<string>(), It.IsAny<string>()), Times.Never);

        }

        [TestMethod]
        public async Task SendWorkouts_InCorrectName_LessThen3()
        {
            // Arrange
            string workoutName = "PD";
			string userId = "";
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			// Act
			var message = await workoutService.SendWorkouts(workoutName, userId);

            // Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
            dataMock.Verify(d => d.SendWorkoutsData(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public async Task SendWorkouts_InCorrectName_MoreThen50()
        {
            // Arrange
            string workoutName = new string('a', 51);
			string userId = "";
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			// Act
			var message = await workoutService.SendWorkouts(workoutName, userId);

            // Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
            dataMock.Verify(d => d.SendWorkoutsData(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }





        [TestMethod]
        public async Task DeleteWorkouts_CorrectID_NotNull()
        {
            //Arrange
            int workoutID = 1;
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			//Act
			var message = await workoutService.DeleteWorkouts(workoutID);

            //Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.DeleteWorkouts(workoutID), Times.Once);
        }

        [TestMethod]
        public async Task DeleteWorkouts_InCorrectID_IsNullOrEmpty()
        {
            //Arrange
            int workoutID = 0;
            var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);
			//Act

			var message = await workoutService.DeleteWorkouts(workoutID);

            //Assert
            Assert.AreEqual("Workout ID is kleiner of gelijk aan 0", message);
            dataMock.Verify(d => d.DeleteWorkouts(It.IsAny<int>()), Times.Never);
        }





        [TestMethod]
        public async Task EditWorkout_CorrectName_CorrectID()
        {
            //Arrange
            string workoutName = "Pizza";
			string userId = "";
			int workoutID = 1;
            var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			//Act
			var message = await workoutService.EditWorkout(workoutName, workoutID, userId);

            //Assert
            Assert.AreEqual("Alles is correct", message);
            dataMock.Verify(d => d.EditWorkouts(workoutName, workoutID, userId), Times.Once);
        }

        [TestMethod]
        public async Task EditWorkout_InCorrectName_IsNullOrEmpty()
        {
            //Arrange
            string workoutName = "";
            int workoutID = 1;
			string userId = "";
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			//Act
			var message = await workoutService.EditWorkout(workoutName, workoutID, userId);

            //Assert
            Assert.AreEqual("Mag niet null zijn", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public async Task EditWorkout_InCorrectName_LessThen3()
        {
            //Arrange
            string workoutName = "PD";
            int workoutID = 1;
			string userId = "";
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			//Act
			var message = await workoutService.EditWorkout(workoutName, workoutID, userId);

            //Assert
            Assert.AreEqual("De naam moet minimaal 3 letters lang zijn", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()), Times.Never);

        }

        [TestMethod]
        public async Task EditWorkout_InCorrectName_moreThen50()
        {
            //Arrange
            string workoutName = new string('a', 51);
			int workoutID = 1;
			string userId = "";
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			//Act
			var message = await workoutService.EditWorkout(workoutName, workoutID, userId);

            //Assert
            Assert.AreEqual("De naam mag maximaal 50 letters lang zijn", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()), Times.Never);

        }

        [TestMethod]
        public async Task EditWorkouts_InCorrectID_NotNull()
        {
            //Arrange
            string workoutName = "Pizza";
            int workoutID = 0;
			string userId = "";
			var dataMock = new Mock<IWorkoutData>();
			var userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);
			var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

			var workoutService = new WorkoutService(dataMock.Object, userManagerMock.Object, httpContextAccessorMock.Object);

			//Act
			var message = await workoutService.EditWorkout(workoutName,workoutID, userId);

            //Assert
            Assert.AreEqual("Workout ID is kleiner of gelijk aan 0", message);
            dataMock.Verify(d => d.EditWorkouts(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()), Times.Never);

        }
    }
}