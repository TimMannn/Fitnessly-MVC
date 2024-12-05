using System.ComponentModel.DataAnnotations;

namespace BLL
{
	public class WorkoutDetails(int id, string name, string userId)
	{
		public int Id { get; } = id;

		[Required(ErrorMessage = "Workout name is required")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Workout name must be between 3 and 50 characters")]
		public string Name { get; } = name;

		public string UserId { get; } = userId;
	}
}