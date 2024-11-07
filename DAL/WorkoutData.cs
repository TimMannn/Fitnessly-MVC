using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class WorkoutData : IWorkoutData
    {
        private string mysqlCon;

        public WorkoutData(string mysqlCon)
        {
            this.mysqlCon = mysqlCon;
        }

        // Haalt op uit database
        public List<WorkoutDetails> GetWorkouts()
        {

            {
                List<WorkoutDetails> workouts = new List<WorkoutDetails>();

                using (var connection = new MySqlConnection(mysqlCon))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("select * from workout", connection);
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int workoutID = reader.GetInt32("workout_id");
                        string workoutName = reader.GetString("workout_name");

                        workouts.Add(new WorkoutDetails(id: workoutID, name: workoutName));
                    }

                    return workouts;
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
                using (var transcation = connection.BeginTransaction())
                {
                    try
                    {
                        string query =
                            $"DELETE FROM exercise WHERE exercise.exercise_id IN(SELECT workoutexercise.exercise_id FROM workoutexercise WHERE workoutexercise.workout_id = {ID})";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transcation;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();

                        string query2 = $"DELETE FROM workout WHERE workout_id = (@ID)";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                        cmd2.Transaction = transcation;
                        cmd2.Parameters.AddWithValue("@ID", ID);
                        cmd2.ExecuteNonQuery();

                        transcation.Commit();
                    }

                    catch (MySqlException ex)
                    {
                        try
                        {
                            transcation.Rollback();
                            throw ex;
                        }

                        catch (MySqlException exRollback)
                        {
                            throw exRollback;
                        }
                    }
                }
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

        public WorkoutDetails GetWorkout(int WorkoutID)
        {
            {
                using (var connection = new MySqlConnection(mysqlCon))
                {
                    var workout = new WorkoutDetails(0, "");
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand("select * from workout WHERE workout_id = @WorkoutID",
                        connection);
                    mySqlCommand.Parameters.AddWithValue("@WorkoutID", WorkoutID);
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int workoutID = reader.GetInt32("workout_id");
                        string workoutName = reader.GetString("workout_name");
                        workout = new WorkoutDetails(id: workoutID, name: workoutName);
                    }

                    return workout;
                }
            }
        }
    }
}