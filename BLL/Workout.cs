using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class Workout(int id, string name)
    {
        public int Id { get; set; } = id;

        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; } = name;
    }
}
