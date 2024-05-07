using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class Workout(int id, string name)
    {
        public int Id { get; set; } = id;

        public string Name { get; set; } = name;
    }
}
