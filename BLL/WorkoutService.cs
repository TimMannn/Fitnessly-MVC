using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

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
			var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
			if (user == null)
			{
				throw new InvalidOperationException("User not found");
			}
			return await _workoutData.GetWorkouts(user.Id);
		}

		public async Task<string> SendWorkouts(string workoutName)
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
				var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
				if (user == null)
				{
					throw new InvalidOperationException("User not found");
				}
				await _workoutData.SendWorkoutsData(workoutName, user.Id);
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

		public async Task<string> EditWorkout(string newWorkoutName, int workoutID)
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
				await _workoutData.EditWorkouts(newWorkoutName, workoutID);
			}
			return message;
		}

		public async Task<WorkoutDetails> GetWorkout(int id)
		{
			return await _workoutData.GetWorkout(id);
		}
	}
}
