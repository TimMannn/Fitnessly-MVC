using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class WorkoutData : IWorkoutData
    {
        string mysqlCon = "server=localhost; user=root; database=fitnessly;";
        public List<Workout> GetWorkouts()
        {
            {
                List<Workout> workouts = new List<Workout>();

                // haal op uit database komt hier
                using (var connection = new MySqlConnection(mysqlCon)) 
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("select * from workout", connection);
                        MySqlDataReader reader = mySqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int workoutID = reader.GetInt32("workout_id");
                            string workoutName = reader.GetString("workout_name");

                            workouts.Add(new Workout(id: workoutID, name: workoutName));
                        }

                        return workouts;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void SendWorkouts(string workoutName)
        {
            // Stuur naar database komt hier
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"INSERT INTO workout (workout_name) VALUES ('{workoutName}');";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
