using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class WorkoutData : IWorkoutData
    {

        public List<Workout> GetWorkouts()
        {
            {
                List<Workout> workouts = new List<Workout>();

                // haal op uit database komt hier
                string mysqlCon = "server=localhost; user=root; database=fitnessly;";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);

                try
                {
                    mySqlConnection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("select * from workout", mySqlConnection);
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
                    mySqlConnection.Close();
                }
            }
        }
    }
}
