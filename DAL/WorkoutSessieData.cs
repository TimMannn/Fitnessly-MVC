using System.Security.Cryptography.X509Certificates;
using BLL;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace DAL
{
    public class WorkoutSessieData : IWorkoutSessieData
    {
        private string mysqlCon;

        private int WorkoutSessieExerciseID;

        public WorkoutSessieData(string mysqlCon)
        {
            this.mysqlCon = mysqlCon;
        }


        public void CreateWorkoutSessie(int WorkoutID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // select workout name van workout id
                        string query = "SELECT workout_name FROM workout WHERE workout_id = @workoutID;";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@workoutID", WorkoutID);
                        var WorkoutName = cmd.ExecuteScalar().ToString();

                        // insert into workoutsessie workout name en tijd 00:00:00
                        string query2 = $"INSERT INTO workoutsessie (workoutsessie_name, workoutsessie_tijd) VALUES (@workoutName, 0);";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                        cmd2.Transaction = transaction;
                        cmd2.Parameters.AddWithValue("@workoutName", WorkoutName);
                        cmd2.ExecuteNonQuery();

                        transaction.Commit();
                    }

                    catch (MySqlException ex)
                    {
                        try
                        {
                            //transaction.Rollback();
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

        public void CreateWorkoutSessieExercise(string WorkoutSessieExerciseName, int WorkoutSessieStatsSets)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // insert into workoutsessieexercise exercise name, sets
                        string query = $"INSERT INTO workoutsessieexercise (workoutsessieexercise_name, workoutsessieexercise_sets) VALUES (@workoutsessieexercise_name, @workoutsessieexercise_sets);";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@workoutsessieexercise_name", WorkoutSessieExerciseName);
                        cmd.Parameters.AddWithValue("@workoutsessieexercise_sets", WorkoutSessieStatsSets);
                        cmd.ExecuteNonQuery();

                        // Uniek id van workoutsessieexercise
                        string query2 = "SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                        cmd2.Transaction = transaction;
                        WorkoutSessieExerciseID = Convert.ToInt32(cmd2.ExecuteScalar());

                        transaction.Commit();
                    }

                    catch (MySqlException ex)
                    {
                        try
                        {
                            transaction.Rollback();
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

        public void CreateWorkoutSessieStats(double WorkoutSessieStatsGewicht, int WorkoutSessieStatsReps)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // intsert into workoutsessieStats gewicht, reps
                        string query3 = $"INSERT INTO workoutsessiestats (workoutsessiestats_gewicht, workoutsessiestats_reps) VALUES (@workoutsessiestats_gewicht, @workoutsessiestats_reps);";
                        MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                        cmd3.Transaction = transaction;
                        cmd3.Parameters.AddWithValue("@workoutsessiestats_gewicht", WorkoutSessieStatsGewicht);
                        cmd3.Parameters.AddWithValue("@workoutsessiestats_reps", WorkoutSessieStatsReps);
                        cmd3.ExecuteNonQuery();

                        // Uniek id van workoutsesiestats
                        string query4 = "SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd4 = new MySqlCommand(query4, connection);
                        cmd4.Transaction = transaction;
                        int WorkoutSessieStatsID = Convert.ToInt32(cmd4.ExecuteScalar());

                        // link van tussentabel leggen
                        string query5 = $"INSERT INTO workoutsessieexerciseworkoutsessiestats (workoutsessieexercise_id, workoutsessiestats_id) VALUES (@workoutSessieExerciseID, @workoutSessieStatsID);";
                        MySqlCommand cmd5 = new MySqlCommand(query5, connection);
                        cmd5.Transaction = transaction;
                        cmd5.Parameters.AddWithValue("@workoutSessieExerciseID", WorkoutSessieExerciseID);
                        cmd5.Parameters.AddWithValue("@workoutSessieStatsID", WorkoutSessieStatsID);
                        cmd5.ExecuteNonQuery();

                        transaction.Commit();
                    }

                    catch (MySqlException ex)
                    {
                        try
                        {
                            transaction.Rollback();
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
    }
}