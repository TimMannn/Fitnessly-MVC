using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BLL;
using DAL.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace IntegrationTestsFitnessly
{
	public class WorkoutControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
	{
		private readonly HttpClient _client;
		private readonly Mock<IWorkoutData> _dataMock;
		private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
		private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
		private readonly WorkoutService _workoutService;

		public WorkoutControllerIntegrationTests(WebApplicationFactory<Program> factory)
		{
			_client = factory.CreateClient();
			_dataMock = new Mock<IWorkoutData>();
			_userManagerMock = new Mock<UserManager<IdentityUser>>(
				Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null
			);
			_httpContextAccessorMock = new Mock<IHttpContextAccessor>();
			_workoutService = new WorkoutService(_dataMock.Object, _userManagerMock.Object, _httpContextAccessorMock.Object);
		}

		//[Fact]
		public async Task GetWorkouts_ReturnsCorrectData()
		{
			// Arrange
			var expectedWorkouts = new List<WorkoutDetails>
			{
				new WorkoutDetails(1, "Workout 1", "user1"),
				new WorkoutDetails(2, "Workout 2", "user2")
			};

			_dataMock.Setup(d => d.GetWorkouts(It.IsAny<string>())).ReturnsAsync(expectedWorkouts);

			// Act
			var response = await _client.GetAsync("/api/Workout");
			response.EnsureSuccessStatusCode();
			var workouts = await response.Content.ReadFromJsonAsync<List<WorkoutDetails>>();

			// Assert
			Xunit.Assert.Equal(expectedWorkouts.Count, workouts.Count);
			Xunit.Assert.Equal(expectedWorkouts[0].Name, workouts[0].Name);
			Xunit.Assert.Equal(expectedWorkouts[0].UserId, workouts[0].UserId);
		}
	}
}
