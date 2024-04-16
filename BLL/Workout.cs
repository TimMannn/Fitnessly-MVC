namespace BLL
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Workout(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
