using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BLL
{
	public class WorkoutService
	{
		private readonly IWorkoutData _workoutData;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public WorkoutService(IWorkoutData workoutData, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_workoutData = workoutData;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<List<WorkoutDetails>> GetWorkouts()
		{
			try
			{
				if (_httpContextAccessor.HttpContext == null)
				{
					Console.WriteLine("HttpContext is null.");
					throw new InvalidOperationException("HttpContext is null");
				}

				var user = _httpContextAccessor.HttpContext.User;
				if (user == null || !user.Identity.IsAuthenticated)
				{
					Console.WriteLine("User not authenticated.");
					throw new InvalidOperationException("User not authenticated");
				}

				Console.WriteLine("HTTP Context User Identity: " + user.Identity.Name);
				var claims = user.Claims;
				foreach (var claim in claims)
				{
					Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
				}

				var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
				if (string.IsNullOrEmpty(userId))
				{
					Console.WriteLine("User ID claim not found.");
					throw new InvalidOperationException("User ID claim not found");
				}

				var identityUser = await _userManager.FindByIdAsync(userId);
				if (identityUser == null)
				{
					Console.WriteLine("User not found in HttpContext.");
					throw new InvalidOperationException("User not found");
				}

				Console.WriteLine("User found: " + identityUser.UserName);
				return await _workoutData.GetWorkouts(identityUser.Id);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in GetWorkoutsAsync: {ex.Message}");
				throw;
			}
		}

		public async Task<string> SendWorkouts(string workoutName, string userId)
		{
			var message = "Alles is correct";
			if (string.IsNullOrEmpty(workoutName))
			{
				message = "Mag niet null zijn";
			}
			else if (workoutName.Length < 3)
			{
				message = "De naam moet minimaal 3 letters lang zijn";
			}
			else if (workoutName.Length > 50)
			{
				message = "De naam mag maximaal 50 letters lang zijn";
			}
			else
			{
				await _workoutData.SendWorkoutsData(workoutName, userId);
			}
			return message;
		}
			

		public async Task<string> DeleteWorkouts(int ID)
		{
			var message = "Alles is correct";
			if (ID <= 0)
			{
				message = "Workout ID is kleiner of gelijk aan 0";
			}
			else
			{
				await _workoutData.DeleteWorkouts(ID);
			}

			return message;
		}

		public async Task<string> EditWorkout(string newWorkoutName, int workoutID, string userId)
		{
			var message = "Alles is correct";
			if (string.IsNullOrEmpty(newWorkoutName))
			{
				message = "Mag niet null zijn";
			}
			else if (newWorkoutName.Length < 3)
			{
				message = "De naam moet minimaal 3 letters lang zijn";
			}
			else if (newWorkoutName.Length > 50)
			{
				message = "De naam mag maximaal 50 letters lang zijn";
			}
			else if (workoutID <= 0)
			{
				message = "Workout ID is kleiner of gelijk aan 0";
			}
			else
			{
				await _workoutData.EditWorkouts(newWorkoutName, workoutID, userId);
			}
			return message;
		}

		public async Task<WorkoutDetails> GetWorkout(int id)
		{
			return await _workoutData.GetWorkout(id);
		}
	}
}
