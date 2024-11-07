using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class WorkoutDetails(int id, string name)
    {
        public int Id { get; } = id;

        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; } = name;
    }
}
