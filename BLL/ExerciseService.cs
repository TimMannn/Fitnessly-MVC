using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BLL
{
	public class ExerciseService
	{
		private readonly IExerciseData _data;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ExerciseService(IExerciseData data, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_data = data;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<List<ExerciseDetails>> GetExercises(int workoutID)
		{
			return await _data.GetExercises(workoutID);
		}

		public async Task<string> SendExercise(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string display, int workoutID)
		{
			var message = "Alles is correct";
			if (string.IsNullOrEmpty(exerciseName))
			{
				message = "Mag niet null zijn";
			}
			else if (exerciseName.Length < 3)
			{
				message = "De naam moet minimaal 3 letters lang zijn";
			}
			else if (exerciseName.Length > 50)
			{
				message = "De naam mag maximaal 50 letters lang zijn";
			}
			else if (exerciseGewicht == 0)
			{
				message = "Het gewicht mag niet 0 zijn.";
			}
			else if (exerciseSets == 0)
			{
				message = "De hoeveelheid sets mag niet 0 zijn.";
			}
			else if (exerciseReps == 0)
			{
				message = "De hoeveelheid reps mag niet 0 zijn.";
			}
			else
			{
				await _data.SendExerciseData(exerciseName, exerciseGewicht, exerciseSets, exerciseReps, display, workoutID);
			}
			return message;
		}

		public async Task<string> DeleteExercise(int ID)
		{
			var message = "Alles is correct";
			if (ID <= 0)
			{
				message = "Exercise ID is kleiner of gelijk aan 0";
			}
			else
			{
				await _data.DeleteExercise(ID);
			}

			return message;
		}

		public async Task<string> EditExercise(string newExerciseName, double newExerciseGewicht, int newExerciseSets, int newExerciseReps, int exerciseID)
		{
			var message = "Alles is correct";
			if (string.IsNullOrEmpty(newExerciseName))
			{
				message = "Mag niet null zijn";
			}
			else if (newExerciseName.Length < 3)
			{
				message = "De naam moet minimaal 3 letters lang zijn";
			}
			else if (newExerciseName.Length > 50)
			{
				message = "De naam mag maximaal 50 letters lang zijn";
			}
			else if (newExerciseGewicht == 0)
			{
				message = "Het gewicht mag niet 0 zijn.";
			}
			else if (newExerciseSets == 0)
			{
				message = "De hoeveelheid sets mag niet 0 zijn.";
			}
			else if (newExerciseReps == 0)
			{
				message = "De hoeveelheid reps mag niet 0 zijn.";
			}
			else if (exerciseID <= 0)
			{
				message = "Exercise ID is kleiner of gelijk aan 0";
			}
			else
			{
				await _data.EditExercise(newExerciseName, newExerciseGewicht, newExerciseSets, newExerciseReps, exerciseID);
			}
			return message;
		}

		public async Task<ExerciseDetails> GetExercise(int id)
		{
			return await _data.GetExercise(id);
		}

		public async Task DisplayTrueExercise()
		{
			await _data.DisplayTrueExercise();
		}

		public async Task DisplayFalseExercise(int exerciseID)
		{
			await _data.DisplayFalseExercise(exerciseID);
		}
	}
}
