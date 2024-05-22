using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class WorkoutData : IWorkoutData
    {
        // connectie string met database
        string mysqlCon = "server=localhost; user=root; database=fitnessly;";

        // Haalt op uit database
        public List<Workout> GetWorkouts()
        {
            {
                List<Workout> workouts = new List<Workout>();

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

        // verstuurd naar database
        public void SendWorkoutsData(string workoutName)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"INSERT INTO workout (workout_name) VALUES (@workoutName);";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@workoutName", workoutName);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // verwijder uit database
        public void DeleteWorkouts(int ID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"DELETE FROM workout WHERE workout_id = (@ID)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // bewerk uit database
        public void EditWorkouts(string NewWorkoutName, int WorkoutID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"UPDATE workout SET workout_name = @NewWorkoutName WHERE workout_id = @WorkoutID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NewWorkoutName", NewWorkoutName);
                cmd.Parameters.AddWithValue("@WorkoutID", WorkoutID);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Workout GetWorkout(int WorkoutID)
        {
            {
                using (var connection = new MySqlConnection(mysqlCon))
                {
                    try
                    {
                        var workout = new Workout(0, "");
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("select * from workout WHERE workout_id = @WorkoutID" , connection);
                        mySqlCommand.Parameters.AddWithValue("@WorkoutID", WorkoutID);
                        MySqlDataReader reader = mySqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int workoutID = reader.GetInt32("workout_id");
                            string workoutName = reader.GetString("workout_name");
                            workout = new Workout(id: workoutID, name: workoutName);
                        }

                        return workout;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
