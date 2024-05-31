using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ExerciseData : IExerciseData
    {
        string mysqlCon = "server=localhost; user=root; database=fitnesslybackup;";

        public List<Exercise> GetExercises(int WorkoutID)
        {
            {
                List<Exercise> exercises = new List<Exercise>();

                using (var connection = new MySqlConnection(mysqlCon))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM exercise WHERE exercise.exercise_id IN (SELECT workoutexercise.exercise_id FROM workoutexercise WHERE workoutexercise.workout_id = {WorkoutID})", connection);
                        MySqlDataReader reader = mySqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int exerciseID = reader.GetInt32("exercise_id");
                            string exerciseName = reader.GetString("exercise_name");
                            double exerciseGewicht = reader.GetDouble("exercise_gewicht");
                            int exerciseSets = reader.GetInt32("exercise_sets");
                            int exerciseReps = reader.GetInt32("exercise_reps");

                            exercises.Add(new Exercise(id: exerciseID, name: exerciseName, gewicht:exerciseGewicht, sets: exerciseSets, reps: exerciseReps));
                        }

                        return exercises;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        // verstuur naar database
        public void SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, int WorkoutID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = $"INSERT INTO exercise (exercise_name, exercise_gewicht, exercise_sets, exercise_reps) VALUES (@exerciseName, @exerciseGewicht, @exerciseSets, @exerciseReps);";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@exerciseName", exerciseName);
                        cmd.Parameters.AddWithValue("@exerciseGewicht", exerciseGewicht);
                        cmd.Parameters.AddWithValue("@exerciseSets", exerciseSets);
                        cmd.Parameters.AddWithValue("@exerciseReps", exerciseReps);
                        cmd.ExecuteNonQuery();

                        string query2 = "SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                        cmd2.Transaction = transaction;
                        int ExerciseID = Convert.ToInt32(cmd2.ExecuteScalar());

                        string query3 = $"INSERT INTO workoutexercise (workout_id, exercise_id) VALUES (@workoutID, @exerciseID);";
                        MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                        cmd3.Transaction = transaction;
                        cmd3.Parameters.AddWithValue("@workoutID", WorkoutID);
                        cmd3.Parameters.AddWithValue("exerciseID", ExerciseID);
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

        // verwijder uit database
        public void DeleteExercise(int ID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                using (var transcation = connection.BeginTransaction())
                {
                    try
                    {
                        string query = $"DELETE FROM exercise WHERE exercise_id = (@ID)";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transcation;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();

                        string query2 = $"DELETE FROM workoutexercise WHERE exercise_id = (@ID)";
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
        public void EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"UPDATE exercise SET exercise_name = @NewExerciseName, exercise_gewicht = @NewExerciseGewicht, exercise_sets = @NewExerciseSets, exercise_reps = @NewExerciseReps WHERE exercise_id = @ExerciseID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NewExerciseName", NewExerciseName);
                cmd.Parameters.AddWithValue("@NewExerciseGewicht", NewExerciseGewicht);
                cmd.Parameters.AddWithValue("@NewExerciseSets", NewExerciseSets);
                cmd.Parameters.AddWithValue("@NewExerciseReps", NewExerciseReps);
                cmd.Parameters.AddWithValue("@ExerciseID", ExerciseID);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Exercise GetExercise(int ExerciseID)
        {
            {
                using (var connection = new MySqlConnection(mysqlCon))
                {
                    try
                    {
                        var exercise = new Exercise(0, "", 0, 0, 0);
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("select * from exercise WHERE exercise_id = @ExerciseID", connection);
                        mySqlCommand.Parameters.AddWithValue("@ExerciseID", ExerciseID);
                        MySqlDataReader reader = mySqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int exerciseID = reader.GetInt32("exercise_id");
                            string exerciseName = reader.GetString("exercise_name");
                            double exerciseGewicht = reader.GetDouble("exercise_gewicht");
                            int exerciseSets = reader.GetInt32("exercise_sets");
                            int exerciseReps = reader.GetInt32("exercise_reps");
                            exercise = new Exercise(id: exerciseID, name: exerciseName, gewicht: exerciseGewicht, sets: exerciseSets, reps: exerciseReps);
                        }

                        return exercise;
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
