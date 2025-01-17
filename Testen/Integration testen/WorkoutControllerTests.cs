using Xunit;
using Moq;
using BLL;
using DAL.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Webapi.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features;
using BLL.Models;

public class WorkoutControllerTests
{
	private readonly Mock<IWorkoutData> _mockWorkoutData;
	private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
	private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
	private readonly WorkoutService _workoutService;
	private readonly WorkoutController _controller;

	public WorkoutControllerTests()
	{
		_mockWorkoutData = new Mock<IWorkoutData>();
		_mockUserManager = new Mock<UserManager<IdentityUser>>(
			Mock.Of<IUserStore<IdentityUser>>(),
			null, null, null, null, null, null, null, null);
		_mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.NameIdentifier, "user1")
		};

		var identity = new ClaimsIdentity(claims, "TestAuthType");
		var claimsPrincipal = new ClaimsPrincipal(identity);

		var httpContext = new DefaultHttpContext
		{
			User = claimsPrincipal
		};

		_mockHttpContextAccessor.Setup(x => x.HttpContext).Returns(httpContext);
		_mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new IdentityUser { Id = "user1", UserName = "TestUser" });

		_workoutService = new WorkoutService(_mockWorkoutData.Object, _mockUserManager.Object, _mockHttpContextAccessor.Object);
		_controller = new WorkoutController(_workoutService);
	}

	[Fact]
	public async Task GetWorkouts_ReturnsOkResult_WithListOfWorkouts()
	{
		// Arrange
		string userId = "user1";
		var mockWorkouts = new List<WorkoutDetails>
		{
			new WorkoutDetails(1, "Workout 1", userId),
			new WorkoutDetails(2, "Workout 2", userId)
		};
		_mockWorkoutData.Setup(service => service.GetWorkouts(userId)).ReturnsAsync(mockWorkouts);

		// Act
		var result = await _controller.GetWorkouts();

		// Assert
		var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
		var returnWorkouts = Xunit.Assert.IsType<List<WorkoutDetails>>(okResult.Value);
		Xunit.Assert.Equal(2, returnWorkouts.Count);
	}

	[Fact]
	public async Task GetWorkout_ReturnsNotFound_WhenWorkoutDoesNotExist()
	{
		// Arrange
		int nonExistentWorkoutId = 999;
		_mockWorkoutData.Setup(service => service.GetWorkout(nonExistentWorkoutId)).ReturnsAsync((WorkoutDetails)null);

		// Act
		var result = await _controller.GetWorkout(nonExistentWorkoutId);

		// Assert
		Xunit.Assert.IsType<NotFoundResult>(result.Result);
	}

	[Fact]
	public async Task PostWorkout_ReturnsCreatedAtAction_WhenWorkoutIsValid()
	{
		// Arrange
		var request = new AddWorkoutModel { WorkoutName = "New Workout", UserId = "user1" };
		_mockWorkoutData.Setup(service => service.SendWorkoutsData(request.WorkoutName, request.UserId)).Returns(Task.CompletedTask);

		// Act
		var result = await _controller.PostWorkout(request);

		// Assert
		var createdAtActionResult = Xunit.Assert.IsType<CreatedAtActionResult>(result.Result);
		var returnWorkout = Xunit.Assert.IsType<AddWorkoutModel>(createdAtActionResult.Value);
		Xunit.Assert.Equal(request.WorkoutName, returnWorkout.WorkoutName);
	}

	[Fact]
	public async Task PutWorkout_ReturnsOk_WhenWorkoutIsValid()
	{
		// Arrange
		var request = new EditWorkoutModel { WorkoutId = 1, WorkoutName = "Updated Workout", UserId = "user1" };
		_mockWorkoutData.Setup(service => service.EditWorkouts(request.WorkoutName, request.WorkoutId, request.UserId)).Returns(Task.CompletedTask);

		// Act
		var result = await _controller.PutWorkout(request.WorkoutId, request);

		// Assert
		var actionResult = Xunit.Assert.IsType<ActionResult<DAL.EntityFramework.Models.Workout>>(result);
		Xunit.Assert.IsType<OkResult>(actionResult.Result);
	}

	[Fact]
	public async Task DeleteWorkout_ReturnsOk_WhenWorkoutExists()
	{
		// Arrange
		int workoutId = 1;
		_mockWorkoutData.Setup(service => service.DeleteWorkouts(workoutId)).Returns(Task.CompletedTask);

		// Act
		var result = await _controller.DeleteWorkout(workoutId);

		// Assert
		Xunit.Assert.IsType<OkResult>(result);
	}
}
