using System.Security.Cryptography.X509Certificates;
using BLL;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace DAL
{
    public class WorkoutSessieData : IWorkoutSessieData
    {
        private string mysqlCon;

        public static class SharedData
        {
            public static int WorkoutSessieExerciseID { get; set; }
            public static int WorkoutSessieID { get; set; }
        }

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

                        string query3 = "SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                        cmd3.Transaction = transaction;
                        SharedData.WorkoutSessieID = Convert.ToInt32(cmd3.ExecuteScalar());


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
                        SharedData.WorkoutSessieExerciseID = Convert.ToInt32(cmd2.ExecuteScalar());

                        string query3 = $"INSERT INTO workoutsessieworkoutsessieexercise (workoutsessie_id, workoutsessieexercise_id) VALUES (@WorkoutSessieID, @WorkoutSessieExerciseID);";
                        MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                        cmd3.Transaction = transaction;
                        cmd3.Parameters.AddWithValue("@WorkoutSessieID", SharedData.WorkoutSessieID);
                        cmd3.Parameters.AddWithValue("@WorkoutSessieExerciseID", SharedData.WorkoutSessieExerciseID);
                        cmd3.ExecuteNonQuery();

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
                        cmd5.Parameters.AddWithValue("@workoutSessieExerciseID", SharedData.WorkoutSessieExerciseID);
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

        public (List<WorkoutSessieExerciseResult>, List<WorkoutSessieExerciseStats>) GetResults()
        {
            List<WorkoutSessieExerciseResult> WorkoutResultsList = new List<WorkoutSessieExerciseResult>();
            List<WorkoutSessieExerciseStats> WorkoutStatsList = new List<WorkoutSessieExerciseStats>();
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // WorkoutSessieID alle exercises
                        string query = "SELECT workoutsessieexercise_id FROM workoutsessieworkoutsessieexercise WHERE workoutsessie_id = @WorkoutSessieID;";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@WorkoutSessieID", SharedData.WorkoutSessieID);
                        List<int> ExerciseIdList = new List<int>();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int exerciseID = reader.GetInt32("workoutsessieexercise_id");
                                ExerciseIdList.Add(exerciseID);
                            }
                        }

                        // Create list Results
                        foreach (int exerciseID in ExerciseIdList)
                        {
                            string query2 = "SELECT workoutsessieexercise_name, workoutsessieexercise_sets FROM workoutsessieexercise WHERE workoutsessieexercise_id = @WorkoutSessieExerciseID;";
                            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                            cmd2.Transaction = transaction;
                            cmd2.Parameters.AddWithValue("@WorkoutSessieExerciseID", exerciseID);

                            using (var reader = cmd2.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string exerciseName = reader.GetString("workoutsessieexercise_name");
                                    int exerciseSets = reader.GetInt32("workoutsessieexercise_sets");

                                    WorkoutResultsList.Add(new WorkoutSessieExerciseResult(name: exerciseName, sets: exerciseSets));
                                }
                            }

                            // workoutsessiestats id ophalen
                            string query3 = "SELECT workoutsessiestats_id FROM workoutsessieexerciseworkoutsessiestats WHERE workoutsessieexercise_id = @WorkoutSessieExerciseID;";
                            MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                            cmd3.Transaction = transaction;
                            cmd3.Parameters.AddWithValue("@WorkoutSessieExerciseID", exerciseID);
                            List<int> ExerciseStatsList = new List<int>();

                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int exerciseStatsID = reader.GetInt32("workoutsessiestats_id");
                                    ExerciseIdList.Add(exerciseStatsID);
                                }
                            }

                            foreach (int exerciseStatsID in ExerciseStatsList)
                            {
                                string query4 = "SELECT workoutsessiestats_gewicht, workoutsessiestats_reps FROM workoutsessiestats WHERE workoutsessiestats_id = @WorkoutSessieStatsID;";
                                MySqlCommand cmd4 = new MySqlCommand(query4, connection);
                                cmd4.Transaction = transaction;
                                cmd4.Parameters.AddWithValue("@WorkoutSessieStatsID", exerciseStatsID);

                                using (var reader = cmd4.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        double Gewicht = reader.GetDouble("workoutsessiestats_gewicht");
                                        int Reps = reader.GetInt32("workoutsessiestats_reps");

                                        WorkoutStatsList.Add(new WorkoutSessieExerciseStats(gewicht: Gewicht, reps: Reps));
                                    }
                                }
                            }
                        }

                        // create list stats



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

            return (WorkoutResultsList, WorkoutStatsList);
        }
    }
}